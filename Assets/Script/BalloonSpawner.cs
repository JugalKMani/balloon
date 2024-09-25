using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System.Collections.Generic;


public class BalloonSpawner : MonoBehaviour
{
    public GameObject[] balloonPrefab; 
    public int poolSize = 10; 
    public float spawnInterval = 1.5f; 
    public Vector2 spawnArea = new Vector2(8f, 5f); 

    private List<GameObject>[] balloonPools; 
    private int b; 

    private void Start()
    {
        
        balloonPools = new List<GameObject>[balloonPrefab.Length];
        for (int i = 0; i < balloonPrefab.Length; i++)
        {
            balloonPools[i] = new List<GameObject>();
            for (int j = 0; j < poolSize; j++)
            {
                GameObject balloon = Instantiate(balloonPrefab[i]);
                balloon.SetActive(false);
                balloonPools[i].Add(balloon); 
            }
        }

        
        InvokeRepeating("SpawnBalloon", 1f, spawnInterval);
    }

    
    void SpawnBalloon()
    {
        float randomX = Random.Range(-spawnArea.x, spawnArea.x);
        float randomY = Random.Range(-spawnArea.y, spawnArea.y);
        Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

        b = Random.Range(0, balloonPrefab.Length); 

        GameObject balloon = GetPooledBalloon(b); 

        if (balloon != null)
        {
            balloon.transform.position = spawnPosition;
            balloon.SetActive(true); 
        }
        else
        {
            Debug.LogWarning("No available balloons in pool.");
        }
    }

   
    GameObject GetPooledBalloon(int balloonType)
    {
        
        if (balloonType < 0 || balloonType >= balloonPools.Length)
        {
            Debug.LogError("Invalid balloon type index.");
            return null;
        }

      
        for (int i = 0; i < balloonPools[balloonType].Count; i++)
        {
            if (!balloonPools[balloonType][i].activeInHierarchy)
            {
                return balloonPools[balloonType][i]; 
            }
        }

      
        Debug.Log("Expanding pool for balloon type: " + balloonType);
        GameObject newBalloon = Instantiate(balloonPrefab[balloonType]);
        newBalloon.SetActive(false);
        balloonPools[balloonType].Add(newBalloon);
        return newBalloon;
    }
}


