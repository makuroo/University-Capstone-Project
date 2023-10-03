using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower Data", menuName = "Create Tower Data")]
public class TowerDatas : ScriptableObject
{
    [Header("Tower")]
    public Sprite sprite;
    public float attackDamage;
    public float magicDamage;
    public float attackSpeed;
}
