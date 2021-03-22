using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUI : MonoBehaviour
{
    public List<GameObject> healthIndicators;
    public GameObject playerObject;
    public Text collectedText;

    // Update is called once per frame
    void Update()
    {
        HealthUIUpdate();
        CollectedTextUpdate();
    }

    private void CollectedTextUpdate()
    {
        if( playerObject == null )
        {
            return;
        }

        int totalCollected = playerObject.GetComponent<Collector>().GetCollectibleCount(CollectibleType.GoalMarkers);

        collectedText.text = "PIECES: " + totalCollected;
    }

    private void HealthUIUpdate()
    {
        if(playerObject == null)
        {
            SetNumHealthIndicators(0);
            return;
        }

        SetNumHealthIndicators(playerObject.GetComponent<Destructible>().GetCurrentHitPoints());
    }

    private void SetNumHealthIndicators(int numHealth)
    {
        for (int i = 0; i < healthIndicators.Count; i++)
        {
            if( numHealth <= i )
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
