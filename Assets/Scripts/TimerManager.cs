using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{

    public float timerPlatform = 15.0f;
    public GameObject piattaformaTimer;
    MeshRenderer AndreaMilitoBatman;
    Color OGcolor; 
    bool attivazione = false;
    private void Awake()
    {
        AndreaMilitoBatman = GetComponent<MeshRenderer>();
        OGcolor = AndreaMilitoBatman.material.color;
    }

    private void Update()
    {
        if (attivazione)
        {
            timerPlatform -= Time.deltaTime;
            Debug.Log(timerPlatform);
            AndreaMilitoBatman.material.color = new Color (0, 1, 1, 0.5f);
        }

        if (timerPlatform <= 0.0f)
        {
            Debug.Log("ci siamo");
            piattaformaTimer.SetActive(false);
            timerPlatform = 7.0f;
            attivazione = false;
            AndreaMilitoBatman.material.color = OGcolor;

        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && attivazione == false)
        {
            attivazione = true;
            piattaformaTimer.SetActive(true);
        }
    }
}
