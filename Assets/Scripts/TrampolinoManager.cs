using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampolinoManager : MonoBehaviour
{
    MeshRenderer AntonioGreco;
    Color ogColor;
    bool check = false;
    float timer = 3.0f;
    public float power = 15.0f;
    

    private void Awake()
    {
        AntonioGreco = GetComponent<MeshRenderer>();
        ogColor = AntonioGreco.material.color;
    }

    private void Update()
    {
        if (check)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0)
        {
            check = false;
            AntonioGreco.material.color = ogColor;
            timer = 3.0f;
        }

    }
    private void OnTriggerStay (Collider other)
    {
        {
            if (!check)
            {
                if (other.tag == "Player")  
                {
                    Debug.Log("collisione");
                    if (PlayerManager.velocity.y < 0 || PlayerManager.velocity.y > 0)
                    {
                    Debug.Log("funziona");
                    check = true;
                    PlayerManager.velocity.y = power;
                    Debug.Log(PlayerManager.velocity);
                    AntonioGreco.material.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                    } 
                }
            }
        }

    }
}
