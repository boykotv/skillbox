using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject lazerShot;
    public GameObject lazerGun;
    public float shotDelay;
    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;
    Rigidbody playerShip;

    float nextShotTime;
    // Start is called before the first frame update
    void Start()
    {
        playerShip = GetComponent<Rigidbody>();  
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        playerShip.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float xPosition = Mathf.Clamp(playerShip.position.x, xMin, xMax);
        float zPosition = Mathf.Clamp(playerShip.position.z, zMin, zMax);

        playerShip.position = new Vector3(xPosition, 0, zPosition);

        playerShip.rotation = Quaternion.Euler(playerShip.position.z * tilt, 0, playerShip.position.x * tilt);

        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity); //создать что, где, угол наклона
            nextShotTime = Time.time + shotDelay;
        }

        
    }
}
