using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWeapon : WeaponBase
{
    [SerializeField] List<GameObject> shootPoint;
    [SerializeField] AnimationClip shootClip;
    private Transform currShootpoint;
    private void Start()
    {
        InitializeData();
    }
    private void Update()
    {
        if (GetComponent<WeaponBase>()._Anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && GetComponent<WeaponBase>()._Anim.GetCurrentAnimatorStateInfo(0).IsName("ArrowTier1"))
        {
            _Anim.Play("New State");
        }
    }

    public override void Shoot()
    {
        
        for(int i=0; i < shootPoint.Count-1; i++)
        {
            if (i == tower.GetComponent<TowerBase>()._Tier)
            {
                shootPoint[i].SetActive(true);
                currShootpoint = shootPoint[i].transform;
            }           
        }
        weaponData[tower.GetComponent<TowerBase>()._Tier].projectile.GetComponent<Projectile>().tower = tower.GetComponent<TowerBase>();
        _Anim.Play("ArrowTier1");
        Debug.Log("anim play");
    }

    public void CreateProjectile()
    {
        Instantiate(weaponData[tower.GetComponent<TowerBase>()._Tier].projectile, currShootpoint.position, Quaternion.identity);
        Debug.Log("shoot");
    }


}
