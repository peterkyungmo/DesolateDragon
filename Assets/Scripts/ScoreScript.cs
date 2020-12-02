using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static int scoreValue = 0;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreValue == 0)
        {
            score.text = "Score: 0  You haven't killed any enemies yet!";
        } else if (scoreValue >= 20)
        {
            score.text = "Score: " + scoreValue + "   You've killed all the enemies!";
        }
        else
        {
            score.text = "Score: " + scoreValue;
        }
    }
}
