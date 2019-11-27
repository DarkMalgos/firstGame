using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public GameObject EnemyPrefab;
    private float t = 0;
    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime;
        if (t > 0.75)
        {
            GameObject g = Instantiate(EnemyPrefab);
            g.transform.position = new Vector3(Random.Range(-25, 25), 1, Random.Range(-25, 25));
            t = 0;
        }
    }
}
