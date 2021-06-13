using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogController : MonoBehaviour
{
    public Transform playerPosition;
    public float maxZRotation;

    public float yMax;
    public float yMin;

    public float movementSpeed;

    public SharedBool isMaximumDistanceReached;

    public bool isTop;
    public SpriteRenderer spriteRenderer;

    public int fadeLoopCount;

    public bool invincible;
    public int lives = 2;

    public Image[] heartRenderers;
    public Sprite emptyHeartSprite;

    public ParticleSystem particles;
    
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

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Hit()
    {
        //change sprite
        if (invincible) return;
        particles.Play();
        lives--;
        heartRenderers[0].color = new Color(1, 1, 1, 1);
        heartRenderers[1].color = new Color(1, 1, 1, 1);
        heartRenderers[1].sprite = emptyHeartSprite;
        if (lives == 0)
        {
            FindObjectOfType<GameOverPanelController>().GameOver(isTop);
            return;
        }
        fadeLoopCount = 0;
        StartCoroutine("FadeImage", true);
        StartCoroutine("FadeHearts", 3f);
        invincible = true;
    }

    IEnumerator FadeHearts(float timer)
    {
        yield return new WaitForSeconds(timer);
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            heartRenderers[0].color = new Color(1, 1, 1, i);
            heartRenderers[1].color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
    
    IEnumerator FadeImage(bool fadeAway)
    {
        if (fadeLoopCount >= 6)
        {
            invincible = false;
            yield break;
        }
        
        // fade from opaque to transparent
        if (fadeAway)
        {
            for (float i = 1; i >= 0; i -= Time.deltaTime)
                {
                    // set color with i as alpha
                    spriteRenderer.color = new Color(1, 1, 1, i);
                    yield return null;
                }

            fadeLoopCount++;
            StartCoroutine("FadeImage", false);
            // loop over 1 second backwards

        }
        // fade from transparent to opaque
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
                {
                    // set color with i as alpha
                    spriteRenderer.color = new Color(1, 1, 1, i);
                    yield return null;
                }
            fadeLoopCount++;
            StartCoroutine("FadeImage", true);
            // loop over 1 second

        }
    }
    
    
}
