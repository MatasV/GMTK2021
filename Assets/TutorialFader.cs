using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialFader : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Image> imagesToFade = new List<Image>();

    private void Start()
    {
        Invoke("StartFading", 7f);
    }

    private void StartFading()
    {
        StartCoroutine(FadeImage(true));
    }
    IEnumerator FadeImage(bool fadeAway)
        {
            // fade from opaque to transparent
            if (fadeAway)
            {
                foreach (var img in imagesToFade)
                {
                    for (float i = 1; i >= 0; i -= Time.deltaTime)
                    {
                        // set color with i as alpha
                        img.color = new Color(1, 1, 1, i);
                        yield return null;
                    }
                }
                // loop over 1 second backwards
                
            }
            // fade from transparent to opaque
            else
            {
                foreach (var img in imagesToFade)
                {
                    for (float i = 0; i <= 1; i += Time.deltaTime)
                    {
                        // set color with i as alpha
                        img.color = new Color(1, 1, 1, i);
                        yield return null;
                    }
                }
                // loop over 1 second
                
            }
        }
}
