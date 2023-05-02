using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_Functionality : MonoBehaviour
{
    float score;
    public double score_rounded;
    public Text pointText;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        points();
    }

    public void points()
    {
        score = score + 0.003f;
        score_rounded = System.Math.Round(score, 0);
        pointText.text = score_rounded + "m";
    }
}
