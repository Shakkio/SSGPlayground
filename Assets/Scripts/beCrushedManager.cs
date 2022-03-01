using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beCrushedManager : MonoBehaviour
{
    public GameObject player;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HitboxMan")
        {
            PlayerManager.deathCount++;
            player.transform.position = PlayerManager.spawnpoint;
        }

    }
}
