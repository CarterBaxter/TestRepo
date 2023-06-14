using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput; //for character movement
    private float verticalInput;
    public float moveSpeed = 5;
    public bool onGround = true;
    private float jumpForce = 500;
    private float gravityModifyer = 1.5f;
    public GameObject bulletPrefab;
    public GameObject gun;

    public int ammo = 15;
    public int lives = 3;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifyer;
        Debug.Log($"Lives: {lives}. Ammo: {ammo}.");
    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }





    void playerMove()
    {
        shoot();
        sprint();
        jump();
        //directional MOVEMENT
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * moveSpeed);
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
    }

    void sprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10;
        }
        else
        {
            moveSpeed = 5;
        }
    }

    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            onGround = false;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void shoot() 
    {
        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            Instantiate(bulletPrefab, gun.transform.position, gun.transform.rotation);
            ammo--;
            Debug.Log($"Ammo: {ammo}");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        { 
            onGround = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ammo"))
        {
            ammo += 10;
            Destroy(other.gameObject);
            Debug.Log($"AMMO: {ammo}");
        }

        if (other.CompareTag("Enemy"))
        {
            lives--;
            Destroy(other.gameObject);
            Debug.Log($"Lives: {lives}");
        }
    }
}
