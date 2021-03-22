using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreOnTrigger : MonoBehaviour
{
    public int scoreToAdd;
    public ScoreKeeper scoreKeeper;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        scoreKeeper.AddPoints(scoreToAdd);
    }
}