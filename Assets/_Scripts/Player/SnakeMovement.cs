using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SnakeMovement : MonoBehaviour
{

    [SerializeField] private List<Transform> bodyParts = new List<Transform>();

    // min distance between each ball.
    [SerializeField] private float minDistance = 0.25f;

    [SerializeField] public int beginSize = 2;
    [SerializeField] private float speed = 10;
    [SerializeField] private float rotationSpeed = 50;

    [SerializeField] private GameObject bodyPrefab;

    [SerializeField] private float totalBodyparts;
    [SerializeField] private Transform cameraPosition;
    [SerializeField] private Transform CureBodyPart;

    public Transform PrevBodyPart;
    private float dis;
    private float minX = -5 ,maxX = 5f; // movements boundaries 
    public CinemachineVirtualCamera cmFreeCam; // used for the camera shake

    void Start()
    {
        // add Body part at start / it can be controled by beginSize variable

        for (int i = 0; i < beginSize - 1; i++)
        {
            AddBodyPart();
        }
    }

    void Update()
    {
        Move();
        GameOver();
        
        totalBodyparts = bodyParts.Count;
        cameraPosition.position = bodyParts[0].transform.position;

    }

    private void GameOver()
    {
        // check if there is no body part alive then end the game 
        if(totalBodyparts == 1)
        {
            bodyParts.RemoveAt(0);
            GameManager.Instance.GameOver();
        }    
    }

    private void Move()
    {

        float curspeed = speed;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float horizOffset = moveHorizontal * rotationSpeed *  Time.deltaTime;

        float rawhori = bodyParts[0].gameObject.transform.position.x + horizOffset;
        float ClampedHoriz = Mathf.Clamp(rawhori , minX , maxX);

        float forward = bodyParts[0].gameObject.transform.position.z + ( curspeed * Time.deltaTime) ;

        bodyParts[0].gameObject.transform.position = new Vector3 (ClampedHoriz , bodyParts[0].gameObject.transform.position.y  , forward );


        // with this method we can move the body part , all what it does that the body parts follow the first body part bodyParts[0] 

        for ( int i = 1; i < bodyParts.Count; i++ )
        {
            CureBodyPart = bodyParts[i];
            PrevBodyPart = bodyParts[i - 1];

            dis = Vector3.Distance(PrevBodyPart.position,CureBodyPart.position);

            Vector3 newpos = PrevBodyPart.position;

            newpos.y = bodyParts[0].position.y;

            float T = Time.deltaTime * dis / minDistance * curspeed;

            if ( T > 0.5f ) T = 0.5f;
            CureBodyPart.position = Vector3.Slerp(CureBodyPart.position, newpos, T);
            CureBodyPart.rotation = Quaternion.Slerp(CureBodyPart.rotation, PrevBodyPart.rotation, T);
        }
    }
    public void AddBodyPart()
    {
        //we add a bodyPart When we Collect a Bodypart / Coin...

        Transform newpart = (Instantiate (bodyPrefab, bodyParts[bodyParts.Count - 1].position, bodyParts[bodyParts.Count - 1].rotation) as GameObject).transform;

        newpart.SetParent(transform);

        bodyParts.Add(newpart);

    }

    public void removeBodyPart()
    {

        Destroy( bodyParts[1].gameObject );
        bodyParts.RemoveAt(1);
        bodyParts[0].transform.position = new Vector3(bodyParts[0].transform.position.x , bodyParts[0].transform.position.y , bodyParts[0].transform.position.z - 0.5f);

        GameManager.Instance.BallonPop();
        _ProcessShake();
    }


    // a simple camera shake system 
    public IEnumerator _ProcessShake()
    {
        Noise(10, 1f);
        yield return new WaitForSeconds(0.1f);
        Noise(0, 0);
    }

    public void Noise(float amplitudeGain, float frequencyGain)
    {
        cmFreeCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitudeGain;
        
        cmFreeCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequencyGain;

    }

    // with this method i can edit the player boundraise
    public void setMinXandMaxX(float _minx , float _maxX)
    {
        minX *= _minx;
        maxX *= _maxX;
    }



}

