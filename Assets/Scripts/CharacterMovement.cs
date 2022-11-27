 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;

 public class CharacterMovement : MonoBehaviour
 {
     private Touch theTouch, theTouchAfter;
     public Transform characterMovement;
     public static float speed = 2.5f;
     public float smooth = 1f;
     private Quaternion targetRotation;
     bool fingerOff = false;
     public float angle = 391.1f;
     // Start is called before the first frame update

     Vector2 VectorFromAngle(float T)
     {
         return new Vector2(Mathf.Cos(T), Mathf.Sin(T));
     }

     void Start()
     {
         Invoke("Update", 20);
         targetRotation = transform.rotation;
     }

     // Update is called once per frame

     void Update()
     {
         if (Input.touchCount > 0 )
         {
             theTouch = Input.GetTouch(0);
             Vector2 touchPos = Camera.main.ScreenToWorldPoint(theTouch.position);

             if (theTouch.phase == TouchPhase.Moved)
             {
                     if (touchPos.x <= 0)
                     {
                        characterMovement.position = new Vector3 (-1.3f, 0, 0);
                     }
                     if (touchPos.x >= 0)
                     {
                        characterMovement.position = new Vector3 (1.3f, 0, 0);
                     }
             }
             if (theTouch.phase == TouchPhase.Ended)
             {
                 fingerOff = true;
             }
         }


         if (fingerOff == true)
         {
             transform.Translate(VectorFromAngle(angle) * speed * Time.deltaTime);
             if (Input.touchCount > 0)
             {
                 theTouchAfter = Input.GetTouch(0);
                 if (theTouchAfter.phase == TouchPhase.Began)
                 {
                     fingerOff = false;
                 }
             }
         }
     }
 }
