using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawGuy : MonoBehaviour
{
    public GameObject player;
    public GameObject pivotPoint;
    public GameObject clawArm;
    public GameObject clawWithArm;
    public float speed = -.005f;
    private Vector2 targetPosition;
    private Vector3 offset = new Vector3(.43f, 1f, 0f);
    public float followSpeed = 5.0f;
    private bool isGrabbing = false;

    void Start()
    {
        StartCoroutine(ExtendAndRetractClaw());
    }

    void Update()
    {
        targetPosition = new Vector2(player.transform.position.x, transform.position.y);
        Vector2 newPosition = Vector2.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
        newPosition.y = Mathf.Clamp(newPosition.y, 3.4f, 12.3f);
        transform.position = new Vector3(newPosition.x, newPosition.y, 11.08f);
        if (transform.position.y >= 3.4f)
        {
            transform.Translate(0, speed, 0);
        }

        // Smoothly move the pivot point to the player's position with the same follow speed as the ClawGuy
        pivotPoint.transform.position = Vector3.Lerp(pivotPoint.transform.position, player.transform.position, Time.deltaTime * followSpeed);

        // Position the claw to the right of the player, below the pivot point
        clawWithArm.transform.position = pivotPoint.transform.position + offset;
    }

    IEnumerator ExtendAndRetractClaw()
    {
        while (true)
        {
            for (float t = 0; t <= 1; t += Time.deltaTime)
            {
                Vector3 targetArmPosition = new Vector3(0, Mathf.Lerp(0, -3, t), 0);
                clawArm.transform.localPosition = targetArmPosition;
                yield return null;
            }

            yield return new WaitForSeconds(5);

            isGrabbing = true;

            for (float t = 0; t <= 1; t += Time.deltaTime)
            {
                Vector3 targetArmPosition = new Vector3(0, Mathf.Lerp(-3, 0, t), 0);
                clawArm.transform.localPosition = targetArmPosition;
                yield return null;
            }

            yield return new WaitForSeconds(1);

            isGrabbing = false;
        }
    }
}