using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneSelector : MonoBehaviour
{
    

    //Change Scene on Button Pressed
    public void goToSceneNumber(int sceneIndex)
    {
        //scene Must Be ADDED to the Build Settings > Scenes in Build
        SceneManager.LoadScene(sceneIndex);
    }




}
