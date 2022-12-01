using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMovement : MonoBehaviour
{
    public float speed = -.001f;
    public Point_Functionality point_functionality;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, speed, 0);
        if(point_functionality.score_rounded >= 150 && point_functionality.score_rounded <= 300)
        {
            speed = -.001f;
        }
        if(point_functionality.score_rounded >= 300 && point_functionality.score_rounded <= 450)
        {
            speed = -.0014f;
        }
        if(point_functionality.score_rounded >= 450 && point_functionality.score_rounded <= 550)
        {
            speed = -.0018f;
        }
        if(point_functionality.score_rounded >= 550 && point_functionality.score_rounded <= 650)
        {
            speed = -.0022f;
        }
        if(point_functionality.score_rounded >= 650 && point_functionality.score_rounded < 1000)
        {
            speed = -.0026f;
        }
        if(point_functionality.score_rounded >= 1000)
        {
            speed = -.003f;
        }
    }
}
