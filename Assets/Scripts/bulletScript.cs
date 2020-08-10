﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    Rigidbody2D rb;
    public float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //setting bullet's rb
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
