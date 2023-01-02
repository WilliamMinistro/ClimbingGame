using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGeneration : MonoBehaviour
{
    public static float speed = -.001f;
    public GameObject coin;
    public float respawnTime = 6.0f;
    bool isCreated;

    System.Random random = new System.Random();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coinWave());
    }

    IEnumerator coinWave()
    {
        while(true){
            int whichLane = random.Next(1,12);
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

    // Update is called once per frame
    void Update()
    {
    }
    private void spawnL()
    {
            int coinSpawn = random.Next(1,15);
            if(coinSpawn == 4)
            {
                int howManyCoins = random.Next(1,5);
                if(howManyCoins == 1)
                {
                    Instantiate(coin, new Vector3(-1.3f, 6, 10), Quaternion.identity);
                }
                if(howManyCoins == 2)
                {
                    Instantiate(coin, new Vector3(-1.3f, 6, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(-1.3f, 8, 10), Quaternion.identity);
                }
                if(howManyCoins == 3)
                {
                    Instantiate(coin, new Vector3(-1.3f, 6, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(-1.3f, 8, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(-1.3f, 10, 10), Quaternion.identity);
                }
                if(howManyCoins == 4)
                {
                    Instantiate(coin, new Vector3(-1.3f, 6, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(-1.3f, 8, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(-1.3f, 10, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(-1.3f, 12, 10), Quaternion.identity);
                }
            }
    }
    private void spawnR()
    {
            int coinSpawn = random.Next(1,15);
            if(coinSpawn == 11)
            {
                int howManyCoins = random.Next(1,5);
                if(howManyCoins == 1)
                {
                    Instantiate(coin, new Vector3(1.3f, 6, 10), Quaternion.identity);
                }
                if(howManyCoins == 2)
                {
                    Instantiate(coin, new Vector3(1.3f, 6, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(1.3f, 8, 10), Quaternion.identity);
                }
                if(howManyCoins == 3)
                {
                    Instantiate(coin, new Vector3(1.3f, 6, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(1.3f, 8, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(1.3f, 10, 10), Quaternion.identity);
                }
                if(howManyCoins == 4)
                {
                    Instantiate(coin, new Vector3(1.3f, 6, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(1.3f, 8, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(1.3f, 10, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(1.3f, 12, 10), Quaternion.identity);
                }
            }
    }
    private void spawnM()
    {
            int coinSpawn = random.Next(1,15);
            if(coinSpawn == 9)
            {
                int howManyCoins = random.Next(1,5);
                if(howManyCoins == 1)
                {
                    Instantiate(coin, new Vector3(0f, 6, 10), Quaternion.identity);
                }
                if(howManyCoins == 2)
                {
                    Instantiate(coin, new Vector3(0f, 6, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(0f, 8, 10), Quaternion.identity);
                }
                if(howManyCoins == 3)
                {
                    Instantiate(coin, new Vector3(0f, 6, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(0f, 8, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(0f, 10, 10), Quaternion.identity);
                }
                if(howManyCoins == 4)
                {
                    Instantiate(coin, new Vector3(0f, 6, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(0f, 8, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(0f, 10, 10), Quaternion.identity);
                    Instantiate(coin, new Vector3(0f, 12, 10), Quaternion.identity);
                }
            }
    }
}
