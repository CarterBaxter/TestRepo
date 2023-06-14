using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private float enemySpeed = 3;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemySpeed += gameManager.wave;
    }

    // Update is called once per frame
    void Update()
    {
        if (! gameManager.gameOver)
        {
            transform.LookAt(player.transform.position);
            transform.Translate(Vector3.forward * enemySpeed * Time.deltaTime);
        }
    }
}
