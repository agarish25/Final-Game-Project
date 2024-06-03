using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallSpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bulletPrefab;
    public Transform bulletPos;

    private float timer;
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
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 4)
        {
            timer = 0;
            shoot();
        }
    }

    void shoot()
    {
        Instantiate(bulletPrefab, bulletPos.position, Quaternion.identity);
    }
    void SpawnRandomBall()
    {
        spawnInterval = Random.Range(3.0f, 5.0f);
        if (player.transform.position.x < bulletPos.position.x) {
            Vector3 spawnPos = new Vector3(spawnPosX - 1.0f, spawnPosY, 0);
        } else if (player.transform.position.x > bulletPos.position.x) {
            Vector3 spawnPos = new Vector3(spawnPosX + 0.3f, spawnPosY, 0);
        }
            

        // instantiate ball at random spawn location
        //Instantiate(ballPrefab, spawnPos, ballPrefab.transform.rotation);
    }
}
