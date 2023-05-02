using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockRotation : MonoBehaviour
{
    System.Random rand = new System.Random();
    float rotationSpeed;
    int rotationDirection;
    // Start is called before the first frame update
    void Start()
    {
        rotationSpeed = (float)rand.NextDouble() * 40 + 10; // Random speed between 10 and 50
        rotationDirection = rand.Next(0, 2) == 0 ? -1 : 1; // Random direction (clockwise or counterclockwise)
    }

    // Update is called once per frame
    void Update()
    {
            transform.Rotate(new Vector3(0,0,rotationSpeed * rotationDirection * (Time.deltaTime)));
    }
}
