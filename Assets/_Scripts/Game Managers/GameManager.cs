using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
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

    [Header("Sounds")]

    [SerializeField] private AudioClip gameOverSound;
    [SerializeField] private AudioClip BallonPopSound;
 
    [SerializeField] private AudioSource audioSource; 

    private ScoreSystem scoreSystem;
    private List<GameObject> players = new List<GameObject>();

    void Start() 
    {
        gameOverPanel.SetActive(false);
        victoryPanel.SetActive(false);
        scoreSystem = GetComponent<ScoreSystem>(); 

        players.Add(GameObject.FindGameObjectWithTag("Player"));
    }

    public void Victory()
    {

        for (int i = 0; i < players.Count; i++)
        {
            players[i].gameObject.SetActive(false);
        }

        Debug.Log("win");
        victoryPanel.SetActive(true);
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        audioSource.PlayOneShot(gameOverSound);
    }
    public void BallonPop()
    {
        audioSource.PlayOneShot(BallonPopSound);
    }
    public void AddScore(int scoreToAddValue)
    {
        scoreSystem.AddPoint(scoreToAddValue);
    }
    public void retry()
    {
        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex);
    }
    public void NextLevel()
    {
        Scene curScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(curScene.buildIndex + 1);
    }
    



    
}
