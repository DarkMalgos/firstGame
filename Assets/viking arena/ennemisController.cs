using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemisController : MonoBehaviour
{
    public GameObject PrefabExplosion;

    // this is called when a collision enter
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameObject explo = Instantiate(PrefabExplosion);
            explo.transform.position = gameObject.transform.position;
            Destroy(explo, 2);
        }
    }
}
