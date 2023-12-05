using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    public static float speed = -.001f;
    public GameObject coin;
    public float respawnTime = 6;
    bool isCreated;
    private float coinSpawnProbability = 0.5f; // Set this according to the desired coin spawn probability
    public float[] laneCooldowns = new float[6];

    System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coinWave());
    }

    IEnumerator coinWave()
    {
        while(true){
            for (int i = 0; i <= 5; i++)
            {
                if (laneCooldowns[i] <= 0)
                {
                    switch (i)
                    {
                        case 1:
                            spawnL();
                            break;
                        case 2:
                            spawnR();
                            break;
                        case 3:
                            spawnM();
                            break;
                        case 4:
                            spawnL();
                            spawnR();
                            break;
                        case 5:
                            spawnL();
                            spawnM();
                            break;
                        case 6:
                            spawnR();
                            spawnM();
                            break;
                    }
                }
            }
            yield return null;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < laneCooldowns.Length; i++)
        {
            if (laneCooldowns[i] > 0)
            {
                laneCooldowns[i] -= Time.fixedDeltaTime;
            }
            else
            {
                laneCooldowns[i] = 0;
            }
        }
    }
    private void spawnL()
    {
        if (laneCooldowns[0] <= 0 && random.NextDouble() <= coinSpawnProbability)
        {
            SpawnCoins(-1.3f);
            laneCooldowns[0] = respawnTime;
        }
    }
    private void spawnR()
    {
        if (laneCooldowns[1] <= 0 && random.NextDouble() <= coinSpawnProbability)
        {
            SpawnCoins(1.3f);
            laneCooldowns[1] = respawnTime;
        }
    }
    private void spawnM()
    {
        if(laneCooldowns[2] <= 0 && random.NextDouble() <= coinSpawnProbability)
        {
            SpawnCoins(0f);
            laneCooldowns[2] = respawnTime;
        }
    }

    private void SpawnCoins(float xPosition)
    {
        int willSpawn = random.Next(0, 3);
        if(willSpawn == 2)
        {
            int howManyCoins = random.Next(1, 4);
            for (int i = 0; i< howManyCoins; i++)
            {
                float yPos = 6 + (i * 2);
                Instantiate(coin, new Vector3(xPosition, yPos, 10), Quaternion.identity);
            }
        }
    }
}
