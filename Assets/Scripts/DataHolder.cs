using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataHolder : MonoBehaviour
{
    public string WinnerScore; //{ get; set; }
    public string Winner; //{ get; set; }
    
    void Awake()
    {
        int objectsCount = FindObjectsOfType<DataHolder>().Length;
    
        if (objectsCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SetStats(string score, string winner)
    {
        WinnerScore = score;
        Winner = winner;
    }
    
    
    
      
}
