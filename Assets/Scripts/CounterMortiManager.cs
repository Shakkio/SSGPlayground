using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterMortiManager : MonoBehaviour
{
    Text nMorti;
    bool FineLivello;
    // Start is called before the first frame update
    void Awake()
    {
        nMorti = GetComponent<Text>();

        if (GameObject.Find("Fine Livello") == true)
        {
            FineLivello = true;
        }
        else
        {
            FineLivello = false;
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        if (FineLivello == false)
        {
            nMorti.text = "Morti: " + PlayerManager.deathCount;
        }
        else
        {
            nMorti.text = "Ben " + PlayerManager.deathCount;
        }
    }
}
