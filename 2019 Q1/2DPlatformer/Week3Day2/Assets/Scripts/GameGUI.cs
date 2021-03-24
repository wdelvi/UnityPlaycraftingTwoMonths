using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameGUI : MonoBehaviour 
{
    public int goalCountToWin;
    public Animator winScreenAnimator;
    public PickupGetter playerPickupGetter;
    public Destructible playerDestructible;
    public Text timerText;

    public List<GameObject> fullHealthIndicators;
    public List<GameObject> fullScoreIndicators;
	
	// Update is called once per frame
	void Update () 
    {
        if( playerPickupGetter.GetPickupCount( PickupType.Goal ) >= goalCountToWin )
        {
            winScreenAnimator.SetTrigger("Show");
        }

        UpdateHealthUI();
        UpdateScoreUI();
        UpdateTimerUI();
    }

    private void UpdateHealthUI()
    {
        int healthPoints = playerDestructible.GetHitPoints();
        
        for (int i = 0; i < fullHealthIndicators.Count; i++ )
        {
            if( i < healthPoints )
            {
                fullHealthIndicators[i].SetActive(true);
            }
            else
            {
                fullHealthIndicators[i].SetActive(false);
            }
        }
    }

    private void UpdateScoreUI()
    {
        int score = playerPickupGetter.GetPickupCount(PickupType.Goal);

        for (int i = 0; i < fullScoreIndicators.Count; i++)
        {
            if (i < score)
            {
                fullScoreIndicators[i].SetActive(true);
            }
            else
            {
                fullScoreIndicators[i].SetActive(false);
            }
        }
    }

    private void UpdateTimerUI()
    {
        timerText.text = Mathf.Floor(Time.time).ToString();
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
