using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawGuy : MonoBehaviour
{
    public GameObject player;
    public GameObject clawArm;
    public float speed = -.005f;
    private Vector2 targetPosition;
    private Vector3 offset = new Vector3(.43f, 1f, 0f);
    public float followSpeed = 5.0f;
    private float downTimer = 0f;
    private float upTimer = 0f;
    private bool movingDown = true;



    void Start()
    {
    }

    void Update()
    {
         targetPosition = new Vector2(1.3f, transform.position.y);
         Vector2 newPosition = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
         newPosition.y = Mathf.Clamp(newPosition.y, 3.4f, 12.3f);
         transform.position = new Vector3(newPosition.x, newPosition.y, 11.08f);

         if (movingDown)
         {
             if (transform.position.y >= 3.4f)
             {
                 transform.Translate(0, speed, 0); // Moving down
             }

             downTimer += Time.deltaTime;

             if (downTimer >= 5f)
             {
                 movingDown = false; // Start moving up
                 downTimer = 0f; // Reset down timer
             }
         }
         else
         {
            transform.Translate(0, -speed, 0);
            upTimer += Time.deltaTime;

            if (upTimer >= 1f)
            {
                GameObject clawArmClone = Instantiate(clawArm, new Vector3(1.73f, 8, 10), Quaternion.identity);
                clawArmClone.SetActive(true);
                Destroy(gameObject);
            }
         }
    }
}