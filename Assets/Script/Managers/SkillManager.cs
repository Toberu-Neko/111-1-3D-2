using UnityEngine;

public class SkillManager : MonoBehaviour
{
    #region Singleton
    public static SkillManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    [Header("�{�ɯ�O")]
    public GameObject waterTemporary;

    [Header("���n��O")]
    public GameObject noSkill;
    public GameObject testWater;
    public GameObject fire;
    public GameObject debug;

}
