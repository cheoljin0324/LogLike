using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptable")]
public class PlayerEntiy : ScriptableObject
{
    public PlayerData playerdata;
}

[System.Serializable]
public class PlayerData
{
    public int hp;
    public float moveSpd;
    public int atkInt;
    public int atkRange;
}
