using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name.Equals("Border0"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.name.Equals("Border1"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.tag.Equals("Log"))
        {
            other.gameObject.GetComponent<LogController>().Hit();
            FindObjectOfType<AudioManager>().Play("Hit");
            Destroy(this.gameObject);
        }
    }
}
