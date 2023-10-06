using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    [SerializeField] List<TowerDatas> towerDatas;
    [SerializeField] ParticleSystem upgradeParticleSystem;
    [SerializeField] SpriteRenderer sr;
    public SpriteRenderer _spriteRenderer { get; private set; }

    [SerializeField] GameObject towerWeapon;
    public GameObject _towerWeapon { get; private set; }

    [SerializeField] int tier;
    public int _tier { get; private set; }
    public float _attackDamage { get; private set; }
    public float _magicDamage { get; private set; }
    public float _attackSpeed { get; private set; }
    public bool isAttacking { get; set; }

    public void InitializeData()
    {
        _spriteRenderer = sr;
        _towerWeapon = towerWeapon;
        _tier = tier;
        _spriteRenderer.sprite = towerDatas[_tier].sprite;
        _attackDamage = towerDatas[_tier].attackDamage;
        _magicDamage = towerDatas[_tier].magicDamage;
        _attackSpeed = towerDatas[_tier].attackSpeed;  
    }

    protected abstract void Attack();
    public void SetAttackDamage(float amount)
    {
        _attackDamage += amount;
    }    
    public void SetMagicDamage(float amount)
    {
        _attackDamage += amount;
    }

    public void Upgrade() 
    {
        upgradeParticleSystem.Play();
        AnimatorStateInfo stateInfo = towerWeapon.GetComponent<WeaponBase>()._anim.GetCurrentAnimatorStateInfo(0);

        //get last played anim time
        float currTime = stateInfo.normalizedTime * towerWeapon.GetComponent<WeaponBase>()._anim.GetCurrentAnimatorStateInfo(0).length;

        WeaponBase weaponBase = towerWeapon.GetComponent<WeaponBase>();

        tier++;

        //reinitialize datas
        InitializeData();
        weaponBase.InitializeData();

        //make transition seamless
        weaponBase._anim.CrossFade(weaponBase._weaponData[_tier].idleAnimStateName, 0, 0, currTime);
    }
}
