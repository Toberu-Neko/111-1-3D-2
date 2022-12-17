using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(EnemyInRange))]
public class DialogueTrigger : MonoBehaviour
{

    //public Dialogue dialogueOld;
    [Tooltip("��m�u�|��ܤ@������ܡA���}�C����ReloadScene�|�A���ҰʡA�ץ��ݭn�ק�s�ɨt�ΡA�����˨ϥΡC")]
    public DialogueScriptableObj[] normalDialogue;

    [Tooltip("��m�|���_���ƪ����")]
    public DialogueScriptableObj[] repeatDialogue;

    public DialogueScriptableObj giveQuestDia;
    public DialogueScriptableObj completeQuestDia;

    private EnemyInRange enemyInRange;
    private DialogueManager dialogueManager;
    private GameObject notePressE;
    private TextMeshProUGUI notePressEText;

    private PlayerStates playerStates;
    private PlayerData playerData;
    private QusetControler qusetControler;
    private PlayerSaveScript playerSaveScript;
    public KeyCode interactionKey = KeyCode.E;
    bool playerInRange;
    int dialogueCounter;
    int repeatDialogueCounter;
    
    private void Start()
    {
        dialogueCounter = 0;
        repeatDialogueCounter = 0;
        playerSaveScript = UIManager.instance.UI.GetComponent<PlayerSaveScript>();
        qusetControler = UIManager.instance.qusetControler;
        dialogueManager = UIManager.instance.dialogueManager;
        notePressE = PlayerManager.instance.player.transform.Find("WorldSpaceCanvas/PressEToTalkNote").gameObject;
        notePressEText = notePressE.transform.Find("PressEToTalk").gameObject.GetComponent<TextMeshProUGUI>();
        playerStates = PlayerManager.instance.player.GetComponent<PlayerStates>();
        playerData = PlayerManager.instance.playerData;
        enemyInRange = GetComponent<EnemyInRange>();
        notePressE.SetActive(false);
        if(repeatDialogue.Length == 0)
        {
            //Debug.LogError(name + " �����_���ƹ�ܥ����[�A�|�ɭP��ܧP�w��H���~�C");
        }


    }
    private void Update()
    {
        if(Input.GetKeyDown(interactionKey) && playerInRange && Cursor.lockState == CursorLockMode.Locked && !enemyInRange.enemyInRange)
        {
            TriggerDialouge();
        }
        if (enemyInRange.enemyInRange && playerInRange && notePressEText.text != "�M���p��")
        {
            notePressEText.text = "�M���p��";
        }
        if (!enemyInRange.enemyInRange && playerInRange && notePressEText.text != "�uE�v����")
        {
            notePressEText.text = "�uE�v����";
        }
    }
    #region �i�J�d��E����
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag ("Player"))
        {            
            playerInRange = true;
            notePressE.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
            notePressE.SetActive(false);
        }
    }
    #endregion
    public void TriggerDialouge()
    {
        notePressE.SetActive(false);
        //playerStates.talkingTo = repeatDialogue[0].NpcName;

        /*if (playerStates.quest != null && playerStates.quest.goal.goalType == QuestGoal.GoalType.Talk && playerStates.talkingTo == playerStates.quest.goal.talkTo)
        {
            playerStates.quest.goal.Talked();
            if (playerStates.quest.goal.IsReached())
            {
                dialogueManager.StartDialogue(completeQuestDia);
                //quest completed and write save
                playerStates.quest.completed = true;
                //playerStates.questFinished[playerStates.quest.index] = true;
                playerStates.quest.isActive = false;

                //give reward
                GiveSkill();
                playerSaveScript.AutoSave();


                playerStates.quest = null;
            }
        }
        else if (giveQuestDia != null && giveQuestDia.quest.completed == false && (playerStates.quest.isActive == false || playerStates.quest == null))
        {
            //�ӱ�����
            dialogueManager.StartDialogue(giveQuestDia);
            playerStates.quest = giveQuestDia.quest;
            qusetControler.QusetAccepted(giveQuestDia.quest);
        }*/
        if (dialogueCounter < normalDialogue.Length)
        {
            if (normalDialogue[dialogueCounter].completed)
            {
                dialogueManager.StartDialogue(repeatDialogue[repeatDialogueCounter]);
                repeatDialogueCounter++;
                if (repeatDialogueCounter == repeatDialogue.Length)
                {
                    repeatDialogueCounter = 0;
                }
            }
            if (!normalDialogue[dialogueCounter].completed)
            {
                dialogueManager.StartDialogue(normalDialogue[dialogueCounter]);
                normalDialogue[dialogueCounter].completed = true;
            }


            if (normalDialogue[dialogueCounter].haveGoal)
            {
                dialogueManager.ChangeGoal(normalDialogue[dialogueCounter].nowGoal);
            }
            if (normalDialogue[dialogueCounter].giveRegen)
            {
                playerStates.regenAble = true;
                playerData.regen = true;
            }

            if (normalDialogue[dialogueCounter].giveSwim)
            {
                playerStates.swimAble = true;
                playerData.swim = true;
            }

            if (normalDialogue[dialogueCounter].giveThrowStone)
            {
                playerStates.throwStoneAble = true;
                playerData.throwStone = true;
            }

            if (normalDialogue[dialogueCounter].giveFire)
            {
                playerStates.throwFireAble = true;
                playerData.throwFire = true;
            }

            if (normalDialogue[dialogueCounter].giveDebug)
            {
                playerStates.throwDebugAble = true;
                playerData.throwDebug = true;
            }


            dialogueCounter++;
        }
        else
        {
            dialogueManager.StartDialogue(repeatDialogue[repeatDialogueCounter]);
            repeatDialogueCounter++;
            if(repeatDialogueCounter == repeatDialogue.Length)
            {
                repeatDialogueCounter = 0;
            }
        }


        /*if (normalDialogue[dialogueCounter].dialogueName == "������a��O" && !playerStates.swimAble)
        {
            playerStates.swimAble = true;
        }
        if (normalDialogue[dialogueCounter].dialogueName == "�����v¡��O" && !playerStates.regenAble)
        {
            playerStates.regenAble = true;
        }
        if (normalDialogue[dialogueCounter].dialogueName == "������ۯ�O" && !playerStates.throwStoneAble)
        {
            playerStates.throwStoneAble = true;
            playerCombat.SelectSkill(1);
        }*/
    }


    void GiveSkill()
    {
        if (playerStates.quest.giveSwim)
            playerStates.swimAble = true;
        if (playerStates.quest.giveRegen)
            playerStates.regenAble = true;
        if(playerStates.quest.giveThrowStone)
            playerStates.throwStoneAble = true;
    }
}
