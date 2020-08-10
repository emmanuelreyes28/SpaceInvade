using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {

    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            print("shoot");
            shootBullet();
        }
    
    }

    private void shootBullet()
    {
        GameObject clone = Instantiate(bulletPrefab) as GameObject;
        clone.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    void FixedUpdate()
    {
        //movement on x-axis
        float horizontalMove = Input.GetAxis("Horizontal") * speed;
        horizontalMove *= Time.deltaTime;
        transform.Translate(horizontalMove, 0, 0);

        //movement on y-axis 
        float verticalMovement = Input.GetAxis("Vertical") * speed;
        verticalMovement *= Time.deltaTime;
        transform.Translate(0, verticalMovement, 0);

        //set x and y boundaries
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.4f, 5.4f), 
        Mathf.Clamp(transform.position.y, -4f, 4f), transform.position.z);
    }

}
