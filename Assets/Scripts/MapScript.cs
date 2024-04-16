using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScript : MonoBehaviour
{
    public int currentSpawn = 0;
    [SerializeField]
    public List<List<float>> mapData = new List<List<float>>();
    [SerializeField]
    PlayerController PlayerController;
    private void Start()
    {
        mapData.Add(new List<float> { -102.82f, 1.2f});
    }
    // Update is called once per frame
    void Update()
    {
        PlayerController.xSpawn = mapData[currentSpawn][0];
        PlayerController.ySpawn = mapData[currentSpawn][1];
    }
}
