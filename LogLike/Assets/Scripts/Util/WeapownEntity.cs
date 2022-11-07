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
    [Header("이름")]
    public string name;
    [Header("ID")]
    public string id;
    [Header("공격력")]
    public int attacker;
    [Header("재장전 대기 시간")]
    public float reload;
    [Header("탄창 갯수")]
    public int bulletAmount;
    [Header("프리팹")]
    public GameObject model;
    [Header("총구")]
    public Transform TPos;
}
