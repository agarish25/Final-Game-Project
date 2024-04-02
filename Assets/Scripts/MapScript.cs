using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public float[,] mapData = { { -2.3581f, -1.82f + 3} };
    public int currentSpawn;

    [SerializeField]
    PlayerController PlayerController;

    // Update is called once per frame
    void Update()
    {
        PlayerController.xSpawn = mapData[currentSpawn, 0];
        PlayerController.ySpawn = mapData[currentSpawn, 1];
    }
}
