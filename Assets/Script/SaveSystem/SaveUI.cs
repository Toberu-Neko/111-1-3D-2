using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class SaveUI : MonoBehaviour
{
    public GameObject[] save_Load_Button;
    private TextMeshProUGUI[] playTimeText, skillText, goalText;

    [SerializeField] private LocalizedString swimLocalizedString;
    [SerializeField] private LocalizedString regenLocalizedString;
    [SerializeField] private LocalizedString throwStoneLocalizedString;
    [SerializeField] private LocalizedString throwFireLocalizedString;
    [SerializeField] private LocalizedString periodLocalizedString;
    [SerializeField] private LocalizedString coma;
    [SerializeField] private LocalizedString noskillLocalizedString;

    [SerializeField] private LocalizedString playtimeLocalizedString;
    [SerializeField] private LocalizedString currentSkillLocalizedString;
    [SerializeField] private LocalizedString goalLocalizedString;

    void Awake()
    {
        playTimeText = new TextMeshProUGUI[save_Load_Button.Length];
        skillText = new TextMeshProUGUI[save_Load_Button.Length];
        goalText = new TextMeshProUGUI[save_Load_Button.Length];
        for (int i = 0; i < save_Load_Button.Length; i++)
        {
            //Debug.Log(save_Load_Button.Length);

            playTimeText[i] = save_Load_Button[i].transform.Find("�C���ɶ�Text").gameObject.GetComponent<TextMeshProUGUI>();
            skillText[i] = save_Load_Button[i].transform.Find("������OText").gameObject.GetComponent<TextMeshProUGUI>();
            goalText[i] = save_Load_Button[i].transform.Find("�ؼ�Text").gameObject.GetComponent<TextMeshProUGUI>();
        }
    }
    private void OnEnable()
    {
        RefreshSave();
    }
    public void RefreshSave()
    {
        for (int i = 0; i < save_Load_Button.Length; i++)
        PreviewSave(i);
    }
    public void PreviewSave(int saveSlot)
    {
        PlayerDataTransfer data = SaveSystem.LoadPlayer(saveSlot);

        float playTime;
        string skillText = "";
        bool haveSkill = false;

        if (data != null)
        {
            playTime = data.playTime;
            playTime -= playTime % 1;
            #region �ޯબ�A�P�w
            if (data.regen)
            {
                skillText += regenLocalizedString.GetLocalizedString() + coma.GetLocalizedString();
                haveSkill = true;
            }
            if (data.swim)
            {
                skillText += swimLocalizedString.GetLocalizedString() + coma.GetLocalizedString();
                haveSkill = true;
            }
            if(data.throwStone)
            {
                skillText += throwStoneLocalizedString.GetLocalizedString() + coma.GetLocalizedString();
                haveSkill = true;
            }
            if (data.throwFire)
            {
                skillText += throwFireLocalizedString.GetLocalizedString() + coma.GetLocalizedString();
                haveSkill = true;
            }
            if (data.throwDebug)
            {
                skillText += " ??? " + coma.GetLocalizedString();
                haveSkill = true;
            }
            if (haveSkill)
            {
                skillText = skillText.Remove(skillText.Length - 1);
                skillText += periodLocalizedString.GetLocalizedString();
            }
            if(!haveSkill)
            {
                skillText = noskillLocalizedString.GetLocalizedString() + periodLocalizedString.GetLocalizedString();
            }
            #endregion

            DisplaySaveSlot(true, saveSlot, playTime, skillText, data.nowGoal);
        }
        if(data == null)
        {
            DisplaySaveSlot(false, saveSlot, -1, "skill", "goal");
        }
    }
    void DisplaySaveSlot(bool haveSave, int saveSlot, float playTime, string skill, string goal)
    {
        if (haveSave)
        {
            #region �ɶ�����
            int day =0, hour =0, minute=0, second=0;
            string secondColon = ":", minColon = ":", hourColon = "";
            while(playTime >= 60)
            {
                playTime -= 60;
                minute++;
                if (minute >= 60)
                {
                    minute -= 60;
                    hour++;
                    if(hour >= 24)
                    {
                        hour -= 24;
                        day++;
                    }
                }
            }
            second = (int)playTime;
            if(second < 10)
            {
                secondColon = ":0";
            }
            if(minute < 10)
            {
                minColon = ":0";
            }
            if(hour < 10)
            {
                hourColon = ":0";
            }
            #endregion

            playTimeText[saveSlot].text = playtimeLocalizedString.GetLocalizedString() + day + hourColon + hour + minColon + minute + secondColon + second;
            skillText[saveSlot].text = currentSkillLocalizedString.GetLocalizedString() + skill;
            goalText[saveSlot].text = goalLocalizedString.GetLocalizedString() + goal;
        }
        if (!haveSave)
        {
            playTimeText[saveSlot].text = "";
            skillText[saveSlot].text = "";
            goalText[saveSlot].text = "Empty";
        }
    }




}
