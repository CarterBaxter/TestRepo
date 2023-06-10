using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput; //for character movement
    private float verticalInput;
    public float moveSpeed = 5;
    public bool onGround = true;
    private float jumpForce = 500;
    private float gravityModifyer = 1.5f;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifyer;

    }

    // Update is called once per frame
    void Update()
    {
        playerMove();
    }





    void playerMove()
    {
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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        { 
            onGround = true;
        }
    }

}
