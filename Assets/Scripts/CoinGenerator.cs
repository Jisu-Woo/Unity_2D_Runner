using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    float waitTime = 1.0f;
    public GameObject Bronze;
    public GameObject Silver;
    public GameObject Gold;
    int randParam;

    void Start()
    {
        StartCoroutine(SpawnCoins());
    }
    IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(1.5f);
        while (true)
        {
            randParam = Random.Range(0, 3);
            yield return new WaitForSeconds(Random.Range(waitTime, waitTime * 2));
            if (randParam == 0)
                Instantiate(Bronze, new Vector3(33.0f, -1.0f, 1.0f), Quaternion.identity);
            else if (randParam == 1)
                Instantiate(Silver, new Vector3(33.0f, -1.0f, 1.0f), Quaternion.identity);
            else if (randParam == 2)
                Instantiate(Gold, new Vector3(33.0f, -1.0f, 1.0f), Quaternion.identity);
        }
    }
}
