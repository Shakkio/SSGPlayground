using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuroDistruttibile : MonoBehaviour
{
    Rigidbody questoRigido;
    bool sano = true;
    bool risvegliato = false;
    MeshRenderer questaMesh;
    Material questoMaterial;

    void Awake()
    {
        questoRigido = GetComponent<Rigidbody>();
        questaMesh = GetComponent<MeshRenderer>();
        questoMaterial = questaMesh.material;
    }

    // Update is called once per frame
    void Update()
    {
        if (!sano)
            risveglio();
    }

    void risveglio()
    {
        if (risvegliato == false)
        {
            questoRigido.isKinematic = false;
            questaMesh.material.color = Color.magenta;
            risvegliato = true;
        }
    }

    void no()
    {
        if (sano == true)
        {
            questoRigido.isKinematic = true;
        }
        else
        {
            questoRigido.isKinematic = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        if (collision.gameObject.tag == "Imperturbabile")
        {
            sano = false;
        }

        if (collision.gameObject.tag == "Player")
        {
            no();
        }

        if (collision.gameObject.tag == "inefficace")
        {
            no();
        }

    }
}
