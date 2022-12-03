using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundTile : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject staticObstaclePrefab;
    [SerializeField] GameObject DynamicObstaclePrefab;


    // public void SpawnObstacle (int obstacleToSpawn , bool spawnDynamicObstacle)
    // {
        
    //     // Spawn the obstace at a random position
    //     for (int i = 0; i < obstacleToSpawn ; i++) 
    //     {
    //         // Choose a random point to spawn the obstacle

    //         int obstacleSpawnIndex = Random.Range(2, 5);
    //         Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
            

    //         // if spawnDynamicObstacle is set to true we will spawn the dyanmic and the static randomly  
    //         if (spawnDynamicObstacle)
    //         {
    //             int random = Random.Range(0,100);
    //             if(random > 50){
    //                 var temp = Instantiate(DynamicObstaclePrefab , spawnPoint.position, Quaternion.identity, transform);
    //                 int obstacleSpawnIndexdynamic = Random.Range(2, 5);
    //                 Transform spawnPointdynamic = transform.GetChild(obstacleSpawnIndex).transform;
    //                 temp.transform.GetChild(0).GetComponent<DynamicObstacle>().PlaceToMoveTo = spawnPointdynamic;
    //             }
    //             else{
    //                 Instantiate(staticObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    //             }
    //         }
    //         else
    //         {
    //             Instantiate(staticObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    //         }       

    //     }
    // }


    public void SpawnCoins (int coinsToSpawn)
    {
        for (int i = 0; i < coinsToSpawn; i++) 
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(gameObject.transform.GetChild(0).GetComponent<Collider>());
        }
    }

    public void SpawnObstacles (int obstacleToSpawn , bool spawnDynamicObstacle)
    {
            // Spawn the obstace at a random position
            int obstacleSpawnIndex = Random.Range(2, 5);
            Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        for (int i = 0; i < obstacleToSpawn ; i++) 
        {
            // if spawnDynamicObstacle is set to true we will spawn the dyanmic and the static randomly  
            if (spawnDynamicObstacle)
            {
                int random = Random.Range(0,100);
                if(random > 50){
                    var temp = Instantiate(DynamicObstaclePrefab ,transform);
                    temp.transform.position = GetRandomPointInCollider(gameObject.transform.GetChild(0).GetComponent<Collider>());
                    int obstacleSpawnIndexdynamic = Random.Range(2, 5);
                    Transform spawnPointdynamic = transform.GetChild(obstacleSpawnIndex).transform;
                    temp.transform.GetChild(0).GetComponent<DynamicObstacle>().PlaceToMoveTo = spawnPointdynamic;
                }
                else{
                    Instantiate(staticObstaclePrefab, GetRandomPointInCollider(gameObject.transform.GetChild(0).GetComponent<Collider>()), Quaternion.identity, transform);
                }
            }
            else
            {
                Instantiate(staticObstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
            }       

        }
    }


    Vector3 GetRandomPointInCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if (point != collider.ClosestPoint(point)) 
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 0.6f;
        point.x *= gameObject.transform.GetChild(0).localScale.x;
        return point;
    }
}
