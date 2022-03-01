using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSettingsManager : MonoBehaviour
{
    Vector3 spawnpoint;
    public GameObject utileReference;
    public GameObject ilPlayer;
    Quaternion perilPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //.position
            PlayerManager.spawnpoint = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

            //.rotation
            perilPlayer.eulerAngles = new Vector3(ilPlayer.transform.rotation.x, utileReference.transform.rotation.eulerAngles.y, ilPlayer.transform.rotation.z);
            Debug.Log(utileReference.transform.rotation.eulerAngles.y);
            PlayerManager.rotationSpawnpoint = perilPlayer.eulerAngles;
        }
    }
}
