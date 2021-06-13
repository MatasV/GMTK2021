using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipOverTime : MonoBehaviour
{
    public float time;
    public float timer = 0;

    
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > time)
        {
            transform.position = new Vector3(transform.position.x - 180, transform.position.y, transform.position.z);
            timer = 0;
        }
    }
}
