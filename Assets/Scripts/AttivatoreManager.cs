using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttivatoreManager : MonoBehaviour
{
    public GameObject Attivato;

    private void OnCollisionEnter(Collision other)
    {
        Attivato.SetActive(true);
        Destroy(this.gameObject);
    }

}
