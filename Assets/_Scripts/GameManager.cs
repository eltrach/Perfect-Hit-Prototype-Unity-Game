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
   




   
    
}
