using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HutongGames.PlayMaker;

public class Steven_Generation : MonoBehaviour
{
    private Vector2 bounds;
    public Point_Functionality point_functionality;
    [SerializeField] private Animator myAnimationController;
    System.Random random = new System.Random();
    public float speed = -.005f;
    public GameObject player;
    public ScreenShake screen_shake;
    public int increment = 1;
    public bool isSlamming = false;
    private bool isDone = false;
    public PlayMakerFSM fsm;
    // Start is called before the first frame update
    void Start()
    {
        myAnimationController.SetBool("Steven", isSlamming);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 3.4f)
        {
            transform.Translate(0, speed, 0);
        }
        if(increment == 5)
        {
            speed = .005f;
            transform.Translate(0, speed , 0);
        }
        if(isDone == false)
        {
            StartCoroutine(Slam());
            isDone = true;
        }
    }

    IEnumerator Slam()
    {
        while(true)
        {
            if(increment == 2)
            {
                isSlamming = true;
                myAnimationController.SetBool("Steven", isSlamming);
            }
            increment = increment + 1;
            yield return new WaitForSeconds(2);
        }
    }

    public void shake()
    {
        screen_shake.TriggerShake();
        fsm.SendEvent("Swipe Down");
    }
}
