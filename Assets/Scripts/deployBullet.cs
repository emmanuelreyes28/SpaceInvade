using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployBullet : MonoBehaviour
{
    public GameObject bulletPrefab;
    private GameObject player;
    public GameObject enemy;
    public float respawnTime = 1f;
    private int enemyCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(enemyWave());
    }

    private void shootBullet()
    {
        GameObject clone = Instantiate(bulletPrefab) as GameObject;
        clone.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
    }

    private void spawnEnemy()
    {
        GameObject enemyClone = Instantiate(enemy) as GameObject;
        enemyClone.transform.position = new Vector2(Random.Range(-5, 5), 5.5f);
        enemyCounter += 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            print("shoot");
            shootBullet();
        }

        if(movingEnemyScript.missed >= 3)
        {
            print("Game Over!");
        }

    }

    IEnumerator enemyWave()
    {
        while(enemyCounter <= 19)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }
}
