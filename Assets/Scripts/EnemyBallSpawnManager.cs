using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallSpawnManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject Enemy;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    private float spawnPosX;
    private float spawnPosY;
    private float change;
    private float increment;

    // Start is called before the first frame update
    void Start()
    {
        change = 0;
        increment = 10;
        spawnPosX = Enemy.transform.position.x;
        spawnPosY = Enemy.transform.position.y;
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
        spawnPosX = Enemy.transform.position.x;
        spawnPosY = Enemy.transform.position.y;
        if (change < 200)
        {
            change += increment;
            ballPrefab.transform.position = new Vector2(spawnPosX + change, spawnPosY);
        } else
        {
            Destroy(ballPrefab);
        }
    }
    void SpawnRandomBall()
    {
        spawnInterval = Random.Range(3.0f, 5.0f);

        Vector3 spawnPos = new Vector3(spawnPosX + 0.3f, spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefab, spawnPos, ballPrefab.transform.rotation);
    }
}
