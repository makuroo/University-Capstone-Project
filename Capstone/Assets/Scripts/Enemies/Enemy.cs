using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public EnemyDetection currTower;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            currTower.RemoveEnemy(gameObject);
            Destroy(gameObject);
        }
            
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
