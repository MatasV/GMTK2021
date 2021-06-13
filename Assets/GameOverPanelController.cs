using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanelController : MonoBehaviour
{
    
    public GameObject panel;
    public TMP_Text whoDied;
    private void Start()
    {
        panel.SetActive(false);
    }

    public void GameOver(bool topDied)
    {
        FindObjectOfType<AudioManager>().Play("GameOver");
        Time.timeScale = 0;
        panel.transform.DOMoveY(384, 0.5f, true);
        panel.SetActive(true);
        if (topDied)
        {
            whoDied.text = "Player 1 Tipped You Over!";
        }
        else
        {
            whoDied.text = "Player 2 Tipped You Over!";
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        FindObjectOfType<AudioManager>().Play("Play");
    }
    
}
