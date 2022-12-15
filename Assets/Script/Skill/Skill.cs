using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "�s��O", menuName = "newSkill")]
public class Skill : ScriptableObject
{
    public int skillSlot;
    [Header("�򥻼ƭ�")]
    public int damage;
    [Tooltip("�CfireRate��i�H�g�X�@�o��O")]
    public float fireRate;
    [Tooltip("�C�g�X�@�o��Ocooldown-fireRate�Acooldown <= 0 �N��O�L��")]
    public float cooldown;
    [Tooltip("��O�L����A�g�LoverHeatCD�}�l�^�_�N�o")]
    public float overHeatCD;
    [Tooltip("����o�g��O��A�g�LstartCountDownTime�}�l�^�_�N�o")]
    public float startCountDownTime;

    [Header("���n��O")]
    public bool isTemporarySkill;
    public bool waterTemporary;

    [Header("���Y�]�w")]
    public float maxThrowForce;
    public float minThrowForce;
    public float maxRightThrowForce;
    public float minRightThrowForce;
    public float throwUpwardForce;

    [Header("�����]�w")]
    public float dieTime;
    public float aimDetectRange;

    public GameObject hitParticle;
}
