using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public GameObject TheWall;
    public GameObject SSG;
    MeshRenderer RenatoGilblas;
    Vector3 startPoint;
    Vector3 endPoint;
    bool raccoltaOggetto = false;
    float tempoNormalizzato = 0.0f;
    float tempoUmanolol = 10f;
    public float distanzaPercorsa;


    private void Start()
    {
        startPoint = TheWall.transform.position;
        endPoint = new Vector3(TheWall.transform.position.x, TheWall.transform.position.y, TheWall.transform.position.z + distanzaPercorsa);
        RenatoGilblas = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if(raccoltaOggetto)
        {
            RenatoGilblas.enabled = false;
            tempoNormalizzato += Time.deltaTime / tempoUmanolol;
            TheWall.transform.position = Vector3.Lerp(startPoint, endPoint, tempoNormalizzato);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(!raccoltaOggetto)
            {
            raccoltaOggetto = true;
            SSG.SetActive(true);
            }
        }
    }
}
