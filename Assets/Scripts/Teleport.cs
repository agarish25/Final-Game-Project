using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject checkpoint;
    public GameObject player;
    public AdjustRespawnList AdjustRespawnList;

    public void teleport()
    {
        player.transform.position = new Vector2(checkpoint.transform.position.x, checkpoint.transform.position.y + 2);
        AdjustRespawnList.teleportedTo();
    }
}
