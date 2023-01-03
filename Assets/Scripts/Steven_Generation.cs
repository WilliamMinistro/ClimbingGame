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
    public ScreenShake screen_shake;
    public int increment = 1;
    public bool isSlamming = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnimationController.SetBool("Steven", isSlamming);
        StartCoroutine(Slam());
    }

    // Update is called once per frame
    void Update()
    {
        if(point_functionality.score_rounded >= 25)
        {
            if(transform.position.y >= 3.4f)
            {
                transform.Translate(0, speed, 0);
            }
            if(increment == 3)
            {
                speed = .005f;
                if(transform.position.y <= 12.5f)
                {
                    transform.Translate(0, speed , 0);
                }
            }
        }
    }

    IEnumerator Slam()
    {
        while(true)
        {
            if(point_functionality.score_rounded >= 25)
            {
                if(increment == 1)
                {
                    isSlamming = true;
                    myAnimationController.SetBool("Steven", isSlamming);
                }
                else if(increment == 2)
                {
                    isSlamming = false;
                    myAnimationController.SetBool("Steven", isSlamming);
                }
                if(increment != 3)
                {
                    increment = increment + 1;
                }
            }
            yield return new WaitForSeconds(4f);
        }
    }

    public void shake()
    {
        screen_shake.TriggerShake();
    }
}
