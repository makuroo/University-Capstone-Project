using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    [SerializeField] List<TowerDatas> towerDatas; 

    [SerializeField] SpriteRenderer sr;
    public SpriteRenderer _SpriteRenderer { get; private set; }

    [SerializeField] GameObject towerWeapon;
    public GameObject _TowerWeapon { get; private set; }

    [SerializeField] int tier;
    public int _Tier { get; private set; }
    [field:SerializeField]
    public float _AttackDamage { get; private set; }
    [field: SerializeField]
    public float _MagicDamage { get; private set; }
    [field: SerializeField]
    public float _AttackSpeed { get; private set; }

    public void InitializeData()
    {
        _SpriteRenderer = sr;
        _TowerWeapon = towerWeapon;
        _Tier = tier;
        _AttackDamage = towerDatas[_Tier].attackDamage;
        _MagicDamage = towerDatas[_Tier].magicDamage;
        _AttackSpeed = towerDatas[_Tier].attackSpeed;
    }

    protected abstract void Attack();
    public void SetAttackDamage(float amount)
    {
        _AttackDamage += amount;
    }    
    public void SetMagicDamage(float amount)
    {
        _AttackDamage += amount;
    }

    public void Upgrade()
    {
        tier++;
        sr.sprite = towerDatas[tier].sprite;

    }
}
