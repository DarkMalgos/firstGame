using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barilController : MonoBehaviour
{
    public GameObject PrefabExplosion;

    private bool isHit;
    private float t;
    private int nbEnnemyInTrigger = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            t = 0;
            isHit = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ennemis")
            ++nbEnnemyInTrigger;
    }

    private void OnTriggerStay(Collider other)
    {
        if (isHit && t >= 3)
        {
            if (other.gameObject.tag == "Ennemis")
            {
                Vector3 dir = other.gameObject.transform.position - gameObject.transform.position;
                other.gameObject.GetComponent<Rigidbody>().AddForce(dir * 30);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (nbEnnemyInTrigger < 1)
            isHit = false;
    }

    private void Update()
    {
        t += Time.deltaTime;
        if (isHit && t >= 3)
        {
            Destroy(gameObject, 0.1f);
            GameObject explo = Instantiate(PrefabExplosion);
            explo.transform.position = gameObject.transform.position;
            Destroy(explo, 2);
        }
    }
}
