using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapawn")]
public class WeapownEntity : ScriptableObject
{
    public WeapownData weapownData;
}

[System.Serializable]
public class WeapownData
{
    [Header("�̸�")]
    public string name;
    [Header("ID")]
    public string id;
    [Header("���ݷ�")]
    public int attacker;
    [Header("������ ��� �ð�")]
    public float reload;
    [Header("źâ ����")]
    public int bulletAmount;
    [Header("������")]
    public GameObject model;
    [Header("�ѱ�")]
    public Transform TPos;
}
