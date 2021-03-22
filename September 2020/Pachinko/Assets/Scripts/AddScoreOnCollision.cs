using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreOnCollision : MonoBehaviour
{
    public int scoreToAdd;
    public ScoreKeeper scoreKeeper;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        scoreKeeper.AddPoints(scoreToAdd);
    }
}

