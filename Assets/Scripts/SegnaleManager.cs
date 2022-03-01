using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegnaleManager : MonoBehaviour
{
    public GameObject cartaCorrispondente;
    MeshRenderer questaMesh;
    public GameObject Segnale;
    Light Luce;

    private void Awake()
    {
        Luce = Segnale.GetComponent<Light>();
        questaMesh = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        if (cartaCorrispondente.GetComponent<MeshRenderer>().enabled == false)
        {
            questaMesh.material.color = Color.green;
            Luce.color = Color.green;
        }
    }
}
