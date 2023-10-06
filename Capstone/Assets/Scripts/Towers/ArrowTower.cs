using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : TowerBase
{
    [SerializeField] float currTime;
    // Start is called before the first frame update
    void Start()
    {
        InitializeData();
        currTime = _attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= Time.deltaTime;
        if (currTime <= 0 && isAttacking)
        {
            Attack();
            currTime = _attackSpeed;
        }
    }

    protected override void Attack()
    {
        _towerWeapon.GetComponent<ArrowWeapon>().Shoot();
    }
}
