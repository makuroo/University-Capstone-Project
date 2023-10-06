using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMove : MonoBehaviour
{
    private Enemy baseClass;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        baseClass = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.right * baseClass._speed;
    }
    
}
