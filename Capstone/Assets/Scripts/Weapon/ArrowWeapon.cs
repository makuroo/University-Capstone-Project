using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowWeapon : WeaponBase
{
    [SerializeField] List<GameObject> shootPointParent;
    [SerializeField] List<Transform> shootPoint;
    [SerializeField] AnimationClip shootClip;
    private GameObject currShootpointParent;
    private AnimatorStateInfo stateInfo;
    private void Start()
    {
        InitializeData();

    }
    private void Update()
    {
        stateInfo = GetComponent<WeaponBase>()._anim.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.normalizedTime > 1 && stateInfo.IsName(_weaponData[tower.GetComponent<TowerBase>()._tier].attackAnimStateName))
        {
            //play idle anim after shoot anim finish
            _anim.Play(_weaponData[tower.GetComponent<TowerBase>()._tier].idleAnimStateName);
        }
    }

    public override void Shoot()
    {
        //set active shootpoint based on current tower tier
        for(int i=0; i < shootPointParent.Count; i++)
        {
            if (i != _weaponData[tower.GetComponent<TowerBase>()._tier].activeShootPointParent)
            {
                shootPointParent[i].SetActive(false);
            }
        }

        shootPointParent[_weaponData[tower.GetComponent<TowerBase>()._tier].activeShootPointParent].SetActive(true);
        currShootpointParent = shootPointParent[_weaponData[tower.GetComponent<TowerBase>()._tier].activeShootPointParent];

        // connect weapon projectile to the tower it originate from
        _weaponData[tower.GetComponent<TowerBase>()._tier].projectile.GetComponent<Projectile>().tower = tower.GetComponent<TowerBase>();

        // play tower weapon shoot anim based on tower tier
        _anim.Play(_weaponData[tower.GetComponent<TowerBase>()._tier].attackAnimStateName);
    }

    public void CreateProjectile()
    {
        //iterate through all of currShootpoint child and instatiate projectile from each of them
        for(int i=0; i < currShootpointParent.transform.childCount; i++)
        {
            shootPoint.Add(currShootpointParent.transform.GetChild(i));
            Instantiate(_weaponData[tower.GetComponent<TowerBase>()._tier].projectile, shootPoint[i].position, transform.rotation);
        }
        
    }
}
