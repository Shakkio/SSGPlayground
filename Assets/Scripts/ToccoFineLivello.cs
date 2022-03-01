using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToccoFineLivello : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Help me out");
            GameObject.Find("BlackFade").GetComponent<MainMenuManager>().FineGioco();
        }
    }
}
