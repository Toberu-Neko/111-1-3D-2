using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DialogueScriptableObj))]
public class DialogueEditor : Editor
{
    //SerializedProperty quest;
    private void OnEnable()
    {
        //quest = serializedObject.FindProperty("quest");
    }
    public override void OnInspectorGUI()
    {
        //int maxWidth = 130;
        base.OnInspectorGUI();
        /*DialogueScriptableObj obj = (DialogueScriptableObj)target;

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent("��ܦW��", "��ܦW�٥u�O�Ω�}�o�����A�b�}�����S���γ~�C"), GUILayout.MaxWidth(maxWidth));
        obj.dialogueName = EditorGUILayout.TextField(obj.dialogueName);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent("NPC�W��", "�п�ܰ���o�ӹ�ܪ�NPC�A�D�`���n�C"), GUILayout.MaxWidth(maxWidth));
        //obj.NpcName = EditorGUILayout.EnumPopup(obj.NpcName);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField(new GUIContent("��ܬO�_���_����", "�Y�Ŀ藍�_���ơA�бN����ܩ�bNPC�}�C�����̫�@���C"), GUILayout.MaxWidth(maxWidth));
        //obj.repeatedly = EditorGUILayout.Toggle(obj.repeatedly);

        EditorGUILayout.LabelField(new GUIContent("�O�_��������", "�Ŀ�~�|��ܥ��ȸԲӦC��"), GUILayout.MaxWidth(maxWidth));
        obj.haveQuest = EditorGUILayout.Toggle(obj.haveQuest);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space();

        if (obj.haveQuest)
        {
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField(new GUIContent("NPC�W��", "�п�ܰ���o�ӹ�ܪ�NPC�A�D�`���n�C"), GUILayout.MaxWidth(maxWidth));
            //EditorGUILayout.BoundsField(quest);
            EditorGUILayout.EndHorizontal();
        }*/
    }
}

