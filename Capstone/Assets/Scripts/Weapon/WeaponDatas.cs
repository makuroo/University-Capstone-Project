using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon Data", menuName = "Create Weapon Data")]
public class WeaponDatas : ScriptableObject
{
    [Header("Weapon")]
    public Sprite sprite;
    public GameObject projectile;
    public string attackAnimStateName;
    public string idleAnimStateName;
    public int activeShootPointParent;
}
