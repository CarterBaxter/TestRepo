using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject ammoPrefab;
    public GameObject enemyPrefab;
    public int wave = 1;
    public bool gameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        spawnWave(wave);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver && playerController.lives < 0) 
        {
            gameOver = true;
            Destroy(playerController.gameObject);
            Debug.Log($"Game Over. Wave: {wave}");
        }


        int enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemies == 0) 
        {
            wave++;
            spawnWave(wave);
        }
    }

    void spawnWave(int waveNum)
    { 
        for (int i = 0; i < waveNum; i++) 
        {
            Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
        }
        Instantiate(ammoPrefab, GenerateRandomPos() - new Vector3(0, 0.75f, 0), ammoPrefab.transform.rotation);
    }



    Vector3 GenerateRandomPos()
    {
        float posX = Random.Range(-49, 40);
        float posZ = Random.Range(-47, 42);

        return new Vector3(posX, 1, posZ);
    }

}
