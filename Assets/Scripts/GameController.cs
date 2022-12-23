using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = System.Random;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] players;
    [SerializeField] private Animator firstCubeAnimator;
    [SerializeField] private Animator secondCubeAnimator;
    private Button button;
    private TextMeshProUGUI txt;
    private TextMeshProUGUI[] playerComp;
    private GameObject player;
    private int i;
    private int value;
    private int j;
    void Start()
    {
        
        button = GameObject.FindGameObjectWithTag("SpinButton").GetComponent<Button>();
        value = 0;
        j = 0;
        i = 0;
        player = players[i];
        playerComp = player.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    

    private void ChangePlayer()
    {
        i++;
        player.GetComponentInChildren<Image>().color = new Color(0, 1f, 0.16f, 0);
        if (i >= players.Length)
            EndGame();
        else
        {
            player = players[i];
            playerComp = player.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
            player.GetComponentInChildren<Image>().color = new Color(0, 1f, 0.16f, 1f);
        }
    }

    public void SpinDice()
    {
        var rnd = new Random();
        var firstCube = rnd.Next(1, 7);
        var secondCube = rnd.Next(2, 8);
        value = firstCube + secondCube;
        firstCubeAnimator.SetInteger("fCube", firstCube);
        secondCubeAnimator.SetInteger("sCube", secondCube);
        txt.text = value.ToString();
        button.interactable = false;
    }

    public void Plus()
    {
        playerComp[1].text = (Convert.ToInt32(playerComp[1].text) + value).ToString();
        var score = playerComp[1].text;
        ChangeMainScore(Convert.ToInt32(score));

    }
    
    public void MultiplicationByTwo()
    {
        playerComp[1].text = (Convert.ToInt32(playerComp[1].text) + value * 2).ToString();
        var score = playerComp[1].text;
        ChangeMainScore(Convert.ToInt32(score));

    }
    
    public void MultiplicationByThree()
    {
        playerComp[1].text = (Convert.ToInt32(playerComp[1].text) + value * 3).ToString();
        var score = playerComp[1].text;
        ChangeMainScore(Convert.ToInt32(score));

    }
    
    public void MultiplicationByFour()
    {
        playerComp[1].text = (Convert.ToInt32(playerComp[1].text) + value * 4).ToString();
        var score = playerComp[1].text;
        ChangeMainScore(Convert.ToInt32(score));

    }
    public void DivisionByTwo()
    {
        playerComp[1].text = (Convert.ToInt32(playerComp[1].text) + value / 2).ToString();
        var score = playerComp[1].text;
        ChangeMainScore(Convert.ToInt32(score));

    }
    
    public void DivisionByThree()
    {
        playerComp[1].text = (Convert.ToInt32(playerComp[1].text) + value / 3).ToString();
        var score = playerComp[1].text;
        ChangeMainScore(Convert.ToInt32(score));

    }
    
    public void DivisionByFour()
    {
        playerComp[1].text = (Convert.ToInt32(playerComp[1].text) + value / 4).ToString();
        var score = playerComp[1].text;
        ChangeMainScore(Convert.ToInt32(score));

    }
    
    public void Minus()
    {
        playerComp[1].text = (Convert.ToInt32(playerComp[1].text) - value).ToString();
        var score = playerComp[1].text;
        ChangeMainScore(Convert.ToInt32(score));

    }

    private void ChangeMainScore(int score)
    {
        j++;
        if (score % 13 == 0)
        {
            playerComp[0].text = (Convert.ToInt32(playerComp[0].text) + score / 13).ToString();
        }

        txt.text = "0";
        button.interactable = true;

        if (j >= 5)
        {
            j = 0;
            ChangePlayer();
        }
    }

    private void EndGame()
    {
        var max = Int32.MinValue;
        var winner = "";
        foreach (var el in players)
        {
            var playerStats = el.gameObject.GetComponentsInChildren<TextMeshProUGUI>();
            var score = Convert.ToInt32(playerStats[0].text);
            if (score > max)
            {
                max = score;
                Debug.Log(max);
                winner = playerStats[2].text;
            }
        }

        var dataHolder = FindObjectOfType<DataHolder>();
        dataHolder.SetStats(max.ToString(), winner);
        SceneManager.LoadScene(1);
    }
}
