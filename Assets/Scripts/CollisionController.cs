using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "ClawGuy_arm(Clone)")
        {
            Debug.Log("Hit");
        }
    }

}
