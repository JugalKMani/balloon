using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBalloon : MonoBehaviour
{
   
    public float minSpeed = 5f;
    public float maxSpeed = 20f;
    public int health;
    private float speed;
    private Vector3 direction;

    void Start()
    {
        
        speed = Random.Range(minSpeed, maxSpeed);
        health = Random.Range(2, 4); 
        direction = Vector3.up;

      
        transform.position = new Vector3(Random.Range(-10f, 10f), -5f, Random.Range(-5f, 5f));
    }

    void Update()
    {
        
        transform.Translate(direction * speed * Time.deltaTime*health);
    }

    
    

}

