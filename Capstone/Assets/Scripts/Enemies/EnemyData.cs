using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpeedType
{
    VerySlow,
    Slow,
    Normal,
    Fast,
    Swift
}

[CreateAssetMenu(fileName = "New Enemy Data", menuName = "Create Enemy Data")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy")]
    public Sprite sprite;
    public Animator _anim;
    public float health;
    public int minCoin;
    public int maxCoin;
    public SpeedType speedType;
}