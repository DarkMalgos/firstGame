using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    [Range(0,1000)]
    private float JumpPower;

    private int nbColliderInTrigger = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float deltaSpeed = Speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody>().AddForce(new Vector3(deltaSpeed, 0, 0));
        if (Input.GetKey(KeyCode.Q))
            GetComponent<Rigidbody>().AddForce(new Vector3(-1 * deltaSpeed, 0, 0));
        if (Input.GetKey(KeyCode.Z))
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1 * deltaSpeed));
        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1 * deltaSpeed));
        if (Input.GetKeyDown(KeyCode.Space) && nbColliderInTrigger > 0)
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpPower, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        ++nbColliderInTrigger;
    }

    private void OnTriggerExit(Collider other)
    {
        --nbColliderInTrigger;
    }
}
