using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI curScore;
    [SerializeField] int curScoreValue;

    void Start() 
    {
        curScore.text = curScoreValue.ToString();
    }

    public void AddPoint(int pointToAdd)
    {
        curScoreValue = pointToAdd + curScoreValue;

        curScore.text = curScoreValue.ToString();
    }


}
