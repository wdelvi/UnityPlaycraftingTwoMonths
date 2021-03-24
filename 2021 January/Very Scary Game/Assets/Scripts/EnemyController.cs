using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Collector playerCollector;

    public List<BehaviorState> possibleStates;

    public float timeInEachState = 10f;

    private BehaviorState currentState;

    private float stateChangeTimer;

    // Start is called before the first frame update
    void Start()
    {
        ChooseRandomState();
    }

    // Update is called once per frame
    void Update()
    {
        if( currentState )
        {
            currentState.Tick();
        }

        stateChangeTimer += Time.deltaTime;

        if( stateChangeTimer >= timeInEachState )
        {
            ChooseRandomState();
        }
    }

    private void ChooseRandomState()
    {
        stateChangeTimer = 0f;

        int newStateIndex = Random.Range(0, possibleStates.Count);

        if( currentState != null )
        {
            currentState.OnExitState();
        }

        currentState = possibleStates[newStateIndex];
    }
}
