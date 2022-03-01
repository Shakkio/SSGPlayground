using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaManager : MonoBehaviour
{

    MeshRenderer questaMesh;
    BoxCollider questoCollider;
    public Material materialeAttraverso;

    void Awake()
    {
        questaMesh = GetComponent<MeshRenderer>();
        questoCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CartaManager.checkcarta == true)
        {
            questoCollider.enabled = false;
            questaMesh.material = materialeAttraverso;
        }
    }
}
