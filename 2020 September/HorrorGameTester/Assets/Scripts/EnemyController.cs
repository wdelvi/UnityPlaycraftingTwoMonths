using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public List<BehaviorState> possibleStates;

    public float timeInEachState = 10f;

    private BehaviorState activeState;

    private float stateChangeTimer;

    // Start is called before the first frame update
    void Start()
    {
        ChooseRandomState();
    }

    // Update is called once per frame
    void Update()
    {
        if (activeState)
        {
            activeState.Tick();
        }

        stateChangeTimer += Time.deltaTime;

        if(stateChangeTimer >= timeInEachState)
        {
            ChooseRandomState();
        }
    }

    private void ChooseRandomState()
    {
        stateChangeTimer = 0f;

        int newStateIndex = Random.Range(0, possibleStates.Count);

        if( activeState != null )
        {
            activeState.OnExitState();
        }

        activeState = possibleStates[newStateIndex];
    }
}
