using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //public float health = 0.5f;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBarScript1 healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {

        //check health
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            //stop game
            Time.timeScale = 0;

        }
        else if(other.gameObject.tag == "Bullet")
        {
            //health -= 0.5f;
            currentHealth -= 100;
            healthBar.SetHealth(currentHealth);
        }
    }
}
