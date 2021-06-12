using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    public Transform playerPosition;
    public float maxZRotation;
    private void Update()
    {
        if (playerPosition.localPosition.x < 0 && transform.rotation.z < maxZRotation)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + Math.Abs(playerPosition.localPosition.x * 3f));
        } else if (playerPosition.localPosition.x > 0 && transform.rotation.z > maxZRotation)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - Math.Abs(playerPosition.localPosition.x * 3f));
        }
    }
}
