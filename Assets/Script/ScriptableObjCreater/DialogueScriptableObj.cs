using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

[System.Serializable]
public struct Line
{
    public string ncpName;
    [TextArea(3,6)]
    public string sentences;
}
[CreateAssetMenu(fileName ="�s���", menuName = "�s�W���")]
public class DialogueScriptableObj : ScriptableObject
{
    [Header("��ܰ򥻸��")]
    //[Tooltip("1XXX���ȭ��@����ܡB2XXX�����ƹ�ܡC�ثe�L�γ~�C")]
    //public int index;
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

    [Header("���")]
    public Line[] lines;

    //public bool ended;
}
