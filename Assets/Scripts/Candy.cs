using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class Candy : MonoBehaviour
{
    private Rigidbody2D rb;

    Random rand = new Random();
    
    // objects to drop 
    private GameObject candy;

    public static GameObject[] candies;

    
    // Time it takes to spawn 
    [Space(3)] 
    public float nextSpawnTimer = 10;
    public float countdown = 10; 
    
    // Spawns on x axis 

    public float xMin = -6;
    public float xMax = 6; 
    
    // Spawn Height 
    public float yMin = 6;
    public float yMax = 9;
    
    void Start()
    {
    }

    private void Update()
    {
        // timer to spawn candy
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            spawn();
            countdown = nextSpawnTimer;
        }
    }

    public void spawn()
    {
        // Gets a random pos
        Vector2 pos = new Vector2(rand.NextFloat(xMin, xMax), rand.NextFloat(yMin, yMax));

        int randCandy = rand.NextInt(0,candies.Length);
        
        GameObject candyPrefab = candies[randCandy];
    
        Rigidbody2D can = Instantiate(candyPrefab, pos);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
            //Destroy the candy if Object tagged Player comes in contact with it
            if (other.CompareTag("Player"))
            {
                //Destroy candy
                Destroy(gameObject);
            }
        }
    
}
