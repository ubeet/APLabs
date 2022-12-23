using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    private void Start()
    {
        var data = FindObjectOfType<DataHolder>();
        var winner = data.Winner;
        var winnerScore = data.WinnerScore;

        var textBoxes = FindObjectOfType<Canvas>().GetComponentsInChildren<TextMeshProUGUI>();
        textBoxes[0].text = "Winner: " + winner;
        textBoxes[1].text = "Score: " + winnerScore;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    
    
}
