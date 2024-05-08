using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public GameObject apple;
    public GameObject spike;
    public GameObject spikefloor;

    int randParam;
    void Start()
    {
        StartCoroutine(SpawnSpecialObjects());
    }
    IEnumerator SpawnSpecialObjects()
    {
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            randParam = Random.Range(0, 3);
            yield return new WaitForSeconds(2.0f);
            if (randParam == 0)
                Instantiate(apple, new Vector3(33.0f, -1.3f, 1.0f), Quaternion.identity);
            else if (randParam == 1)
                Instantiate(spike, new Vector3(33.0f, Random.Range(-1, 3), 1.0f), Quaternion.identity);
            else if (randParam == 2)
                Instantiate(spikefloor, new Vector3(33.0f, -1.3f, 1.0f), Quaternion.identity);
        }
    }
}
