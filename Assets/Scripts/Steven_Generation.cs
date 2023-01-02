using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steven_Generation : MonoBehaviour
{
    private Vector2 bounds;
    public Point_Functionality point_functionality;
    [SerializeField] private Animator myAnimationController;
    System.Random random = new System.Random();
    public float speed = -.005f;
    // Start is called before the first frame update
    void Start()
    {
        myAnimationController.SetBool("Steven", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(point_functionality.score_rounded >= 25)
        {
            if(transform.position.y >= 3.4f)
            {
                transform.Translate(0, speed, 0);
                myAnimationController.SetBool("Steven", true);
            }
            else if (transform.position.y <= 3.4f)
            {
                myAnimationController.SetBool("Steven", false);
            }
        }
    }
}
