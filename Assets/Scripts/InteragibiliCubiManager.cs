using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteragibiliCubiManager : MonoBehaviour
{
    public Transform Paretemobile;
    public float timerMurone = 3.0f;
    bool variabiledelDestino = false;
    MeshRenderer andreaMilito;
    BoxCollider christianValletta;
    Vector3 endPoint;
    Vector3 startPoint;
    float m_miServe = 0.0f;
    public float ancheQuesto = 3.0f;
    public float distanzaPercorsa = 20.0f;

    private void Awake()
    {
        andreaMilito = GetComponent<MeshRenderer>();
        christianValletta = GetComponent<BoxCollider>();
    }

    private void Start()
    {
        startPoint = Paretemobile.position;
        endPoint = new Vector3(Paretemobile.position.x, Paretemobile.position.y - distanzaPercorsa, Paretemobile.position.z);
    }
    private void Update()
    {
        if (variabiledelDestino)
        {
            andreaMilito.enabled = false;
            christianValletta.enabled = false;
            timerMurone -= Time.deltaTime;
            //normalizzo nella speranza che funzioni, è il tempo che impiega per compiere l'azione
            m_miServe += Time.deltaTime / ancheQuesto;
            Paretemobile.position = Vector3.Lerp(startPoint, endPoint, m_miServe);
        }    

        if (timerMurone <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!variabiledelDestino)
        {
            variabiledelDestino = true;
        }
    }
}
