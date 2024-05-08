using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundScrolling : MonoBehaviour
{
    private float scrollForeground = 8.0f;
    float moveCheck = 0.0f;
    void Start()
    {
        //transform.position = Vector3.zero;
    }
    void Update()
    {
        moveCheck -= scrollForeground * Time.deltaTime;
        transform.position = new Vector3(moveCheck, 0.8f, 1);
        if (moveCheck < -21.5f)
            moveCheck = 0.0f;
    }
}
