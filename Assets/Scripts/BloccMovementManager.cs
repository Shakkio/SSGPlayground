using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloccMovementManager : MonoBehaviour
{
    public float speed = 7.0f;
    

    private void Start()
    {
        if (DistributoreManager.estrazione == 0)
        {
            transform.position = new Vector3(transform.position.x + 2.7f, transform.position.y, transform.position.z - 1);
        }

        if (DistributoreManager.estrazione == 1)
        {
            transform.position = new Vector3(transform.position.x - 2.7f, transform.position.y, transform.position.z - 1);
        }

        if (DistributoreManager.estrazione == 2)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 1.2f, transform.position.z - 1);
        }

        if (DistributoreManager.estrazione == 3)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1 * speed * Time.deltaTime);

        if (InterruptorManager.staccaTutto == true)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BucoNero")
        {
             Debug.Log("uora ma minu ueue");
             Destroy(this.gameObject);
        }
    }

}
