using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float movementSpeed;
    // Start is called before the first frame update
    public bool isTop;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Equals("Border0"))
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.name.Equals("Border1"))
        {
            Destroy(this.gameObject);
        }
        if (other.tag.Equals("Player"))
        {
            FindObjectOfType<AudioManager>().Play("Coin");
            if (isTop)
                Score.topScore += 1;
            else
                Score.bottomScore += 1;
            Destroy(this.gameObject);
        }
    }
}
