using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Main : MonoBehaviour
{
    private float time = 0;
    private double spawnRate = 5;
    public GameObject enemy;
    public Game game;
    // Start is called before the first frame update
    void Start()
    {
        game = GetComponent<Game>();
        CreateEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= spawnRate)
        {
            CreateEnemy();
            time = 0;
        }
    }

    void CreateEnemy()
    {
        Vector3 enemySpawn = new Vector3(Random.Range(-15f, 15f), 12f, 0);
        Instantiate(enemy, enemySpawn, Quaternion.identity);
    }
}