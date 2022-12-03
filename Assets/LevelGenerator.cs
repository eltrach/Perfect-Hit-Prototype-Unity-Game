using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Level Generator")]
    [SerializeField] GameObject groundObj = null;
    [SerializeField] GameObject groundPlane = null;
    
    [SerializeField] float lengthMinValue;
    [SerializeField] float lengthMaxValue;

    [SerializeField] float widthMinValue;
    [SerializeField] float widthMaxValue;


    [Header("Spawner")]

    [SerializeField] GameObject[] CoinPrefabs;
    [SerializeField] GameObject[] ObstaclePrefabs;

    [SerializeField] float density;

    [SerializeField] private List<GameObject> spawnedCoins = new List<GameObject>();

    public void generateNewLevel()
    {
        ResetToDefault();
        groundObj.transform.localScale =
            new Vector3(Random.Range(widthMinValue,widthMaxValue) , 1 ,Random.Range(lengthMinValue,lengthMaxValue));

        SpawnCoins();
    }
    

    public void SpawnCoins()
    {
        for (int i = 0; i < density; ++i)
        {    
            Vector3 groundScale = groundPlane.transform.localScale;
            Vector3 spawnPos = groundPlane.transform.position;
            GameObject temp =  Instantiate(CoinPrefabs[0] , spawnPos , Quaternion.identity);


            spawnedCoins.Add(temp);
          //  temp.transform.position = new Vector3(temp.transform.position.x , 0.6f , temp.transform.position.z);
           // temp.transform.position = GetRandomPointsInCollider(groundCollider);
        }
       
    }
    public Vector3 GetRandomPointsInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        
        // if (point != collider.ClosestPoint(point)) 
        // {
        //     point = GetRandomPointsInCollider(collider);
        // }

        point.y = 0.6f ;
        return point;
    }

    public void ResetToDefault()
    {
        groundObj.transform.localScale = Vector3.one;

        for (int i = 0; i < spawnedCoins.Count; i++)
        {
            DestroyImmediate(spawnedCoins[i].gameObject);
        }
        spawnedCoins.Clear();

    }




}
