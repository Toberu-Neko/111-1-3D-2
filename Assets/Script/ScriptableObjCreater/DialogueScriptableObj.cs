using UnityEngine;
using UnityEngine.Localization;

[System.Serializable]
public struct Line
{
    public string ncpName;
    public LocalizedString localizedncpName;
    [TextArea(3,6)]
    public string sentences;
    public LocalizedString localizedSentences;
}
[CreateAssetMenu(fileName ="�s���", menuName = "�s�W���")]
public class DialogueScriptableObj : ScriptableObject
{
    [Header("��ܰ򥻸��")]
    public string dialogueName;
    public QuestGoal.TalkToTarget NpcName;
    public bool isTutorial;
    public bool completed;

    [Header("���ȸ�ơ]�ȮɽФŨϥΡ^")]
    [HideInInspector] public bool haveQuest;
    [HideInInspector] public Quest quest;

    [Header("��ܵ�����O")]
    public bool giveRegen;
    public bool giveThrowStone;
    public bool giveSwim;
    public bool giveFire;
    public bool giveDebug;

    [Header("���²�����ܥؼ�")]
    public bool haveGoal;
    public string nowGoal;
    public LocalizedString localizedNowGoal;

    [Header("���")]
    public Line[] lines;
}
