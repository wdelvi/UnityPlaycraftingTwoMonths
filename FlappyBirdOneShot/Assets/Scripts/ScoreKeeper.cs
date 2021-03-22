using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Text scoreText;

    private int score;

    // Update is called once per frame
    void Update()
    {
        score = (int)Time.time;

        scoreText.text = "SCORE: " + score;
    }
}
