using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float bulletSpeed = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkBounds();
        transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
    }


    void checkBounds()
    {
        if (transform.position.x < -54 || transform.position.x > 45) 
        { 
            Destroy(gameObject);
        }
        if (transform.position.z < -52 || transform.position.z > 47)
        {
            Destroy(gameObject);
        }
        if (transform.position.y < -5 || transform.position.y > 50)
        { 
            Destroy (gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

}
