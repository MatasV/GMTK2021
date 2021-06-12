using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererController : MonoBehaviour
{
    public float maxLength;
    public float currentLength;

    public bool isMax;

    public SpriteRenderer sprite;

    public Transform firstPoint;
    public Transform secondPoint;
    private void Update()
    {
        sprite.transform.position = firstPoint.position + sprite.transform.localScale/2;
        
        Vector2 dir = secondPoint.position - firstPoint.position;
 
        //sprite.transform.rotation =
          //  Quaternion.Euler(0, 0, Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x));

        sprite.transform.localScale = new Vector3(1, Math.Abs(firstPoint.position.y - secondPoint.position.y), 0);
    }
}
