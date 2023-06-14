using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingPlayer : MonoBehaviour
{
    private GameObject player;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameOver)
        {
            transform.LookAt(player.transform.position);
        }
    }
}
