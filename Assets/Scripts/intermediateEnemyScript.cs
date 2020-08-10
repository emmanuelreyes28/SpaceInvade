using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intermediateEnemyScript : MonoBehaviour
{
    public float speed = 2f;
    //amount to move left and right from the start point
    public float delta = 2f;
    private Vector2 startPos;
    public static float health = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //move enemy back and forth on x axis 
        Vector2 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;

        //check health
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
            health -= 0.1f;
        }
    }
}
