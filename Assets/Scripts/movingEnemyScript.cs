using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingEnemyScript : MonoBehaviour
{
    public float speed = 1f;
    Rigidbody2D rb;
    public static int missed = 0;
    public float health = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        //rb.velocity = new Vector2(0, -speed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.up * (Time.deltaTime * 1.5f);

        if(transform.position.y < -5.5f)
        {
            Destroy(gameObject);
            missed += 1;
        }
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Bullet")
        {
            health -= 1f;
        }
    }
}
