using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaManager : MonoBehaviour
{
    public static bool checkcarta = false;
    MeshRenderer questaMesh;
    BoxCollider questoCollider;

    private void Awake()
    {
        questaMesh = GetComponent<MeshRenderer>();
        questoCollider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!checkcarta)
            {
                checkcarta = true;
                questoCollider.enabled = false;
                questaMesh.enabled = false;
            }
            else
            {
                questoCollider.enabled = false;
                questaMesh.enabled = false;
            }
        }
    }
}
