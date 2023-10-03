using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public TowerBase tower;
    public float attackDamage;
    public float magicDamage;

    [SerializeField] float speed;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackDamage = tower._AttackDamage;
        magicDamage = tower._MagicDamage;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log(tower._AttackDamage);
            Debug.Log(tower._MagicDamage);
        }
    }
}
