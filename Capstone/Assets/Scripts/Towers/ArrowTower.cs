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
        currTime = _AttackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        currTime -= Time.deltaTime;
        if (currTime <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            currTime = _AttackSpeed;
        }
    }

    protected override void Attack()
    {
        _TowerWeapon.GetComponent<ArrowWeapon>().Shoot();
    }
}
