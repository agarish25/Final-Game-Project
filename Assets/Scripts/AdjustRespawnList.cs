using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustRespawnList: MonoBehaviour
{
    [SerializeField]
    MapScript mapScript;

    public bool activated = false;
    private int number = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (activated)
            {
                mapScript.currentSpawn = number;
            }
            else
            {
                activated = true;
                number = mapScript.mapData.Count;
                mapScript.mapData.Add(new List<float> { transform.position.x, transform.position.y + 3 });
            }
        }
    }
}
