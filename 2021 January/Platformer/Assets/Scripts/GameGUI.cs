using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGUI : MonoBehaviour
{
    public List<GameObject> healthIndicators;
    public Destructible trackedDestructible;
    public GameObject loseScreen;

    public void Start()
    {
        loseScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if( trackedDestructible == null )
        {
            SetHealthIndicators(0);
            loseScreen.SetActive(true);
            return;
        }

        SetHealthIndicators(trackedDestructible.GetCurrentHitPoints());
    }

    private void SetHealthIndicators(int numHitPoints)
    {
        for( int i = 0; i < healthIndicators.Count; i++ )
        {
            if( numHitPoints <= i )
            {
                healthIndicators[i].SetActive(false);
            }
            else
            {
                healthIndicators[i].SetActive(true);
            }
        }
    }
}
