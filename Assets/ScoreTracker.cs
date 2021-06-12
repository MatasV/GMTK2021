using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public bool isTop;

    public TMP_Text text;
    // Update is called once per frame
    void Update()
    {
        if (isTop)
        {
            text.text = Score.topScore.ToString();
        }
        else
        {
            text.text = Score.bottomScore.ToString();
        }
    }
}
