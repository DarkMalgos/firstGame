using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathZoneScript : MonoBehaviour
{
    public Transform RespawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Ennemis")
            Destroy(other.gameObject);
        else if (other.gameObject.tag == "Player")
            other.gameObject.transform.position = RespawnPoint.position;
    }
}
