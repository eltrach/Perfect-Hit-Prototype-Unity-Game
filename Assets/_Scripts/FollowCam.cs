using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    float followSmoothness = 10f;
    [SerializeField]
    private Transform Camera;
    [SerializeField]
    private Transform player;



    void LateUpdate() 
    {
        Camera.position = Vector3.Lerp(Camera.position , player.position , followSmoothness * Time.deltaTime);
    }




}
