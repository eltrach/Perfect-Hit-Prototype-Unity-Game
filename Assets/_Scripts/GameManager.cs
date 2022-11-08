using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton 
    private static GameManager instance;

    public static GameManager Instance {
        get {
            if(instance==null) {
                instance = new GameManager();
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance) 
        {
            DestroyImmediate (gameObject);
        } 
        else 
        {
            DontDestroyOnLoad (gameObject);
            instance = this;
        }
	}
    #endregion
   
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject youWinPanel;


    private ScoreSystem scoreSystem;

    void Start() 
    {
        scoreSystem = GetComponent<ScoreSystem>();    
    }

    public void Victory()
    {

    }

    public void GameOver()
    {
        Debug.Log( "Your Died  ");
        Time.timeScale = 0f;
    }
    public void AddScore(int scoreToAddValue)
    {
        scoreSystem.AddPoint(scoreToAddValue);
    }



    
}
