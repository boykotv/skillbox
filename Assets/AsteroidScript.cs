using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject playerExplosion;
    public float rotationSpeed;
    public float minSpeed, maxSpeed;


    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;

        float zSpeed = Random.Range(minSpeed, maxSpeed);
        asteroid.velocity = new Vector3(0, 0, -zSpeed);
    }


    //при начале столкновения, other - объект, с которым столкнулись
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "GameBoundary")
        {
            //если астероид врезался в границу - не уничтожать ее
            return;
        }

        Destroy(gameObject);
        Destroy(other.gameObject);

        if (other.tag == "Player")
        {
            //показать взрыв игрока
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }
        

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
    }
        
    
}
