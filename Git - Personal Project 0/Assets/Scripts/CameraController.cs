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



    }

    private void LateUpdate()
    {
        //Have camera follow player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.6f, player.transform.position.z);
        
    }
}
