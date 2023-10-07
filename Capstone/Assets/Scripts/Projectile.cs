using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public TowerBase tower;
    public float attackDamage;
    public float magicDamage;

    [SerializeField] float speed;
    [SerializeField] float lifeTime;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackDamage = tower._attackDamage;
        magicDamage = tower._magicDamage;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
            Destroy(gameObject);
        rb.velocity = transform.up * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(tower._attackDamage, tower._magicDamage);
            Debug.Log(collision.transform.GetComponent<Enemy>()._health);
            Destroy(gameObject);
        }
    }
}
