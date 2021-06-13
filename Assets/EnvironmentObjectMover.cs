using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObjectMover : MonoBehaviour
{
    public float speed, destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Destroy", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }

    void Destroy()
    {
        Destroy(gameObject);
    }
}
