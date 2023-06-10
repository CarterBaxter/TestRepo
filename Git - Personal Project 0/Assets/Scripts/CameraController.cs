using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    public float mouse_h; //for mouse movement
    public float mouse_v;
    public float xSen = 100;
    public float ySen = 100;
    private float xRotation;
    private float yRotation;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

        Cursor.lockState = CursorLockMode.Locked; //locks cursor in middle of screen
        Cursor.visible = true; //for now

    }

    // Update is called once per frame
    void Update()
    {
        mouse_h = Input.GetAxisRaw("Mouse X") * xSen;
        mouse_v = Input.GetAxisRaw("Mouse Y") * ySen;

        xRotation -= mouse_v; //add new input to what it was last frame
        yRotation += mouse_h; //inverted by default so subtract to make it like normal mouse controlls

        xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f); //keep vertical looking limited to 90 degrees up and down

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); //set rotation to new location

        player.transform.rotation = Quaternion.Euler(0, yRotation, 0); //rotate player in y directions with camera so directional movements still work

    }



    private void LateUpdate()
    {
        //Have camera follow player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.6f, player.transform.position.z);
    }
}
