using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    Rigidbody CorpoRigido;
    public float bulletSpeed;
    float tempoAutodistruzione = 7.0f;

    void Awake()
    {
        CorpoRigido = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        tempoAutodistruzione -= Time.deltaTime;
        CorpoRigido.AddForce(transform.TransformDirection(Vector3.forward) * bulletSpeed , ForceMode.Impulse);
        if(tempoAutodistruzione < 0)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Imperturbabile" && collision.gameObject.tag != "Player") 
        {
            Debug.Log(collision.gameObject.name);
            Destroy(this.gameObject);
        }
    }
}
