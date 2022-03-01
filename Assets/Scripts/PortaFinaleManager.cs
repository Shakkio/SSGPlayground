using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortaFinaleManager : MonoBehaviour
{
    public GameObject luce1;
    public GameObject luce2;
    public GameObject luce3;
    public GameObject luce4;

    MeshRenderer questaMesh;
    BoxCollider questoCollider;
    public Material materialeAttraverso;


    private void Awake()
    {
        questaMesh = GetComponent<MeshRenderer>();
        questoCollider = GetComponent<BoxCollider>();
    }

    void Update()
    {

        if(luce1.GetComponent<MeshRenderer>().material.color == Color.green)
        {
            if(luce2.GetComponent<MeshRenderer>().material.color == Color.green)
            {
                if(luce3.GetComponent<MeshRenderer>().material.color == Color.green)
                {
                    if(luce4.GetComponent<MeshRenderer>().material.color == Color.green)
                        {

                        questoCollider.enabled = false;
                        questaMesh.material = materialeAttraverso;

                    }
                }
            }
        }
    }
}
