using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComparsaManager : MonoBehaviour
{
    public GameObject cartaCorrispondente;

    MeshRenderer questaMesh;
    BoxCollider questoBox;


    private void Awake()
    {
        questaMesh = GetComponent<MeshRenderer>();
        questoBox = GetComponent<BoxCollider>();
    }
    void Update()
    {
        if (cartaCorrispondente.GetComponent<MeshRenderer>().enabled == false)
        {
            this.questaMesh.enabled = true;
            this.questoBox.enabled = true;
        }
    }
}
