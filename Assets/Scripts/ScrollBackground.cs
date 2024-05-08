using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private float scrollBackground = 8.0f;
    float moveCheck = 0.0f;
    void Start()
    {
        transform.position = Vector3.zero;
    }
    void Update()
    {
        moveCheck -= scrollBackground * Time.deltaTime;
        transform.position = new Vector3(moveCheck, 0, 0);
        if (moveCheck < -21.5f)
            moveCheck = 0.0f;
    }
}
