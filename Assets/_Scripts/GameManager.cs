using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            //DontDestroyOnLoad (gameObject);
            instance = this;
        }
	}
    #endregion
   
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject victoryPanel;

    private ScoreSystem scoreSystem;


    [SerializeField] private GameObject[] player;
    void Start() 
    {
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
        scoreSystem = GetComponent<ScoreSystem>(); 

        player = GameObject.FindGameObjectsWithTag("collect");

    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
        for (int i = 0; i < player.Length; i++)
        {
            player[i].SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
    
    public void AddScore(int scoreToAddValue)
    {
        scoreSystem.AddPoint(scoreToAddValue);
    }
    public void retry()
    {
        Time.timeScale = 1f;
        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex);
    }
    public void NextLevel()
    {
        Time.timeScale = 1f;
        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex + 1);
    }
    



    
}
