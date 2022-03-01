using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistributoreManager : MonoBehaviour
{
    public GameObject[] blockers;
    float timerShoot = 0.5f;
    public static int estrazione;

    void Update()
    {
        timerShoot -= Time.deltaTime;
        if (timerShoot <= 0)
        {
            estrazione = Random.Range(0, 4);
            GameObject bloccoattivo = blockers[estrazione];

            Instantiate(bloccoattivo, transform.position, Quaternion.identity);
            timerShoot = 1.0f;
        }
    }
}
