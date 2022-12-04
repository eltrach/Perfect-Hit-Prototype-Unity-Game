using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI curScore;
    [SerializeField] private TextMeshProUGUI highscore;
    [SerializeField] int curScoreValue;
    [SerializeField] int highScoreValue;

    void Start() 
    {
        highScoreValue = PlayerPrefs.GetInt("highScoreValue");
        curScore.text = curScoreValue.ToString();
        highscore.text = highScoreValue.ToString();

        GetHighScore();

    }

    public void AddPoint(int pointToAdd)
    {
        curScoreValue = pointToAdd + curScoreValue;
        curScore.text = curScoreValue.ToString();
        GetHighScore();
    }
    public void GetHighScore()
    {
        if(curScoreValue >= highScoreValue)
        {
            highScoreValue = curScoreValue;
            PlayerPrefs.SetInt("highScoreValue", highScoreValue);
            highscore.text = highScoreValue.ToString();
        }            
    }
    


}
