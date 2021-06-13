using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassMover : MonoBehaviour
{
    Material mat;
    Vector2 offset;

    public int xVel;
    private int yVel;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(xVel, yVel);
        mat.mainTextureOffset += offset * Time.deltaTime;
    }
}
