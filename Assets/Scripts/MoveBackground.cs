using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public GameObject background;
    public float speed = -.001f;
    bool isCreated;
    public Point_Functionality point_functionality;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(point_functionality.score_rounded >= 150 && point_functionality.score_rounded <= 300)
        {
            speed = -.0012f;
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
        transform.Translate(0, speed, 0);
        if(transform.position.y <= -4)
        {
            if(!isCreated)
            {
                Instantiate(background, new Vector3(0.166101f, 13.95f, 12.65f), Quaternion.identity);
                isCreated = true;
            }
        }
    }
}
