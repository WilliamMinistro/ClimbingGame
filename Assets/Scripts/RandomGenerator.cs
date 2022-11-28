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
            spawnL();
            spawnR();
            spawnM();
//            spawnBandage();
//            yield return new WaitForSeconds(respawnTime);
            yield return new WaitForSeconds(respawnTime);
        }
    }

    private void spawnL()
    {
        int willSpawn = random.Next(1,10);
        if(willSpawn == 2)
        {
            Instantiate(stalagmite, new Vector3(-1.3f, 6, 10), Quaternion.identity);
        }
    }
    private void spawnM()
    {
        int willSpawn = random.Next(1,10);
        if(willSpawn == 2)
        {
            Instantiate(stalagmite, new Vector3(0f, 6, 10), Quaternion.identity);
        }
    }
    private void spawnR()
    {
        int willSpawn = random.Next(1,10);
        if(willSpawn == 2)
        {
            Instantiate(stalagmite, new Vector3(1.3f, 6, 10), Quaternion.identity);
        }
    }

//    private void spawnR()
//    {
//        int whichObj2 = random.Next(1, 4);
//
//        if (isSpikeCol == false)
//        {
//            if (whichObj2 == 1)
//            {
//                randVariableRight = random.Next(6, 10);
//                yValueRight = yValueRight + randVariableRight;
//                Instantiate(spikeClone, new Vector3(1.95f, (yValueRight), 0f), Quaternion.Euler(0, 0, 90));
//            }
//            if(whichObj2 == 2)
//            {
//                randVariableRight = random.Next(6, 10);
//                yValueRight = yValueRight + randVariableRight;
//                Instantiate(FireClone, new Vector3(1.62f, (yValueRight), 0f), Quaternion.Euler(0, 0, 180));
//            }
//            if (whichObj2 == 3)
//            {
//                randVariableRight = random.Next(6, 10);
//                yValueRight = yValueRight + randVariableRight;
//                Instantiate(SpinningSpikeClone2, new Vector3(3.11f, (yValueRight), 0f), Quaternion.Euler(0, 0, 90));
//            }
//        }
//        else
//        {
//            randVariableRight = random.Next(7, 10);
//            yValueRight = yValueRight + randVariableRight;
//        }
//
//        isSpikeCol = false;
//
//    }

//    private void spawnBandage()
//    {
//        int bandagePlacement = random.Next(1, 4);
//
//        if(bandagePlacement == 2)
//        {
//            int randYVal = random.Next(6, 10);
//            yValueBand = yValueBand + randYVal;
//            Instantiate(bandageClone, new Vector3(0f, yValueBand, 0f), Quaternion.Euler(0, 0, 0));
//        }
//        else
//        {
//            int randYVal = random.Next(6, 10);
//            yValueBand = yValueBand + randYVal;
//        }
//
//    }

//


}
