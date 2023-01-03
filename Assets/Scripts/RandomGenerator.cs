﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomGenerator : MonoBehaviour
{
    public float respawnTime = 1.5f;
    private Vector2 bounds;
    public int difficulty;
    public GameObject fireball;
    public GameObject rock;
    public GameObject stalagmite;
    public Point_Functionality point_functionality;
    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        difficulty = 8;  // Difficulty starts at 8, since it is the upper bound of an RNG. As it gets lower, it gets more difficult.
        StartCoroutine(objectWave());
    }

    // Update is called once per frame
    void Update()
    {
        if(point_functionality.score_rounded >= 150 && point_functionality.score_rounded <= 300)
        {
            difficulty = 7;
            respawnTime = 1.25f;
        }
        if(point_functionality.score_rounded >= 300 && point_functionality.score_rounded <= 450)
        {
            difficulty = 6;
        }
        if(point_functionality.score_rounded >= 450 && point_functionality.score_rounded <= 550)
        {
            difficulty = 5;
            respawnTime = 1.0f;
        }
        if(point_functionality.score_rounded >= 550 && point_functionality.score_rounded <= 650)
        {
            difficulty = 4;
            respawnTime = .95f;
        }
        if(point_functionality.score_rounded >= 650 && point_functionality.score_rounded < 1000)
        {
            respawnTime = .9f;
        }
        if(point_functionality.score_rounded >= 1000)
        {
            respawnTime = .85f;
        }
    }

    IEnumerator objectWave()
    {
        while(true){
            int whichLane = random.Next(1,7);
            if(whichLane == 1)
            {
                spawnL();
            }
            if(whichLane == 2)
            {
                spawnR();
            }
            if(whichLane == 3)
            {
                spawnM();
            }
            if(whichLane == 4)
            {
                spawnL();
                spawnR();
            }
            if(whichLane == 5)
            {
                spawnL();
                spawnM();
            }
            if(whichLane == 6)
            {
                spawnR();
                spawnM();
            }
            yield return new WaitForSeconds(respawnTime);
        }
    }

    private void spawnL()
    {
        int willSpawn = random.Next(1,difficulty);
        if(willSpawn == 1)
        {
            Instantiate(stalagmite, new Vector3(-1.3f, 6, 10), Quaternion.identity);
        }
        if(willSpawn == 2)
        {
            Instantiate(fireball, new Vector3(-1.3f, 6, 10), Quaternion.identity);
        }
        if(willSpawn == 3)
        {
            Instantiate(rock, new Vector3(-1.3f, 6, 10), Quaternion.identity);

        }
    }
    private void spawnM()
    {
        int willSpawn = random.Next(1,difficulty);
        if(willSpawn == 1)
        {
            Instantiate(stalagmite, new Vector3(0f, 6, 10), Quaternion.identity);
        }
        if(willSpawn == 2)
        {
            Instantiate(fireball, new Vector3(0f, 6, 10), Quaternion.identity);

        }
        if(willSpawn == 3)
        {
            Instantiate(rock, new Vector3(0f, 6, 10), Quaternion.identity);
        }
    }
    private void spawnR()
    {
        int willSpawn = random.Next(1,difficulty);
        if(willSpawn == 1)
        {
            Instantiate(stalagmite, new Vector3(1.3f, 6, 10), Quaternion.identity);
        }
        if(willSpawn == 2)
        {
            Instantiate(fireball, new Vector3(1.3f, 6, 10), Quaternion.identity);
        }
        if(willSpawn == 3)
        {
            Instantiate(rock, new Vector3(1.3f, 6, 10), Quaternion.identity);
        }
    }
}
