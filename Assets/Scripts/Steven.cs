using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steven : MonoBehaviour
{
    private Vector2 bounds;
    public GameObject steven;
    System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < 10)
        {
            transform.Translate(0f, 3.42f, 9.68f);
        }
    }
}
