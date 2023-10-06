using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    private TowerBase tower;
    [SerializeField] private WeaponBase towerWeapon;
    [SerializeField] protected List<GameObject> enemies;

    private void Start()
    {
        tower = GetComponentInParent<TowerBase>();
        towerWeapon = transform.parent.GetComponentInChildren<WeaponBase>();
    }

    private void Update()
    {
        if (gameObject != null)
        {
            if (enemies.Count > 0)
            {
                tower.isAttacking = true;
                towerWeapon._currTarget = enemies[0];
                towerWeapon.FaceTarget(tower.transform.GetChild(1));
            }

            if (enemies.Count <= 0)
            {
                tower.isAttacking = false;
                towerWeapon._currTarget = null;
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyEnter"))
        {
            enemies.Add(collision.transform.parent.gameObject);
            collision.GetComponentInParent<Enemy>().currTower = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyExit"))
        {
            enemies.Remove(collision.transform.parent.gameObject);
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }
}
