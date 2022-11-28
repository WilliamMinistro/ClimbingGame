using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomGenerator : MonoBehaviour
{
    public static float respawnTime = 2f;
    private Vector2 bounds;
    public int randVariable, randVariableRight;
    public GameObject fireball;
    public GameObject rock;
    public GameObject stalagmite;


    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(objectWave());
    }

    // Update is called once per frame
    void Update()
    {
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
//            spawnBandage();
//            yield return new WaitForSeconds(respawnTime);
            yield return new WaitForSeconds(respawnTime);
        }
    }

    private void spawnL()
    {
        int willSpawn = random.Next(1,10);
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
        int willSpawn = random.Next(1,10);
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
        int willSpawn = random.Next(1,10);
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
