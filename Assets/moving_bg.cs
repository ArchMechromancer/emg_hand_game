using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_bg : MonoBehaviour
{
    public float speed = 0.9f;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
