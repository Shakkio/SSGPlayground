using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterManager : MonoBehaviour
{

    public Transform tpZone;
    public GameObject thePlayer;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("i mean");
            thePlayer.transform.position = new Vector3(tpZone.transform.position.x, tpZone.transform.position.y + 2.5f, tpZone.transform.position.z);
        }
    }
}
