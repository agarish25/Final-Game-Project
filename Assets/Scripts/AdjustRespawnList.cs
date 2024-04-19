using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustRespawnList: MonoBehaviour
{
    [SerializeField]
    MapScript mapScript;

    public Button button;

    public bool activated = false;
    private int number = 0;

    public void teleportedTo()
    {
        mapScript.currentSpawn = number;
    }

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
                button.gameObject.SetActive(true);
                number = mapScript.mapData.Count;
                mapScript.mapData.Add(new List<float> { transform.position.x, transform.position.y + 3 });
                mapScript.currentSpawn = number;
            }
        }
    }
}
