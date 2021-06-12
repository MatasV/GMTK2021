using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogController : MonoBehaviour
{
    public Transform playerPosition;
    public float maxZRotation;

    public float yMax;
    public float yMin;

    public float movementSpeed;

    public SharedBool isMaximumDistanceReached;

    public bool isTop;
    private void Update()
    {
        
        if (playerPosition.localPosition.x < 0 && transform.rotation.z < maxZRotation)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + Math.Abs(playerPosition.localPosition.x * 3f));
        } else if (playerPosition.localPosition.x > 0 && transform.rotation.z > -maxZRotation)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z - Math.Abs(playerPosition.localPosition.x * 3f));
        }
        
        if (playerPosition.localPosition.x < 0 && transform.position.y < yMax )
        {
            if (isMaximumDistanceReached.Value)
            {
                if (!isTop)
                    transform.position += Vector3.up * Math.Abs(playerPosition.localPosition.x) * movementSpeed;
            }
            else transform.position += Vector3.up * Math.Abs(playerPosition.localPosition.x) * movementSpeed;

        } else if (playerPosition.localPosition.x > 0 && transform.position.y > yMin)
        {
            if (isMaximumDistanceReached.Value)
            {
                if (isTop)
                    transform.position += Vector3.down * Math.Abs(playerPosition.localPosition.x) * movementSpeed;
            }
            else
            {
                transform.position += Vector3.down * Math.Abs(playerPosition.localPosition.x) * movementSpeed;
            }
        }
        
        
    }
}
