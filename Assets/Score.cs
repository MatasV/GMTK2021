using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;

public class Score : MonoBehaviour
{
    public static int scoreVal = 0;
    public TMP_Text scoreText;


    private void Update()
    {
        scoreText.text = "Score: " + scoreVal;
    }
}
