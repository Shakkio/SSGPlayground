using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterruptorManager : MonoBehaviour
{
    public static bool staccaTutto = false;

    private void OnCollisionEnter(Collision other)
    { 
    GameObject.Find("Distributore").GetComponent<DistributoreManager>().enabled = false;
       staccaTutto = true;
    }
}
