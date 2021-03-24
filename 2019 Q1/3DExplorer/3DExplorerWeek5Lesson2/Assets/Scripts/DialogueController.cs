using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour 
{
    public float minTalkDistance;
    public Transform target;
    public List<string> talkingStrings;
    public GameObject talkPrompt;
    public Text talkText;

    private int talkTextIndex;
    private bool showingDialgoue;
    private NPCController nPCController;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minTalkDistance);
    }

	// Use this for initialization
	void Start () 
    {
        talkTextIndex = 0;
        showingDialgoue = false;
        nPCController = GetComponent<NPCController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if( target )
        {
            if( IsWithinDistance( minTalkDistance ) )
            {
                DetectInput();
            }
            else if( showingDialgoue )
            {
                EndDialogue();
            }
        }
	}

    private void DetectInput()
    {
        if( Input.GetKeyUp( KeyCode.T ) )
        {
            if( showingDialgoue == false )
            {
                BeginDialogue();
            }
            else if( talkTextIndex < talkingStrings.Count - 1 )
            {
                ProgressDialogue();
            }
            else
            {
                EndDialogue();
            }
        }
    }

    private void BeginDialogue()
    {
        showingDialgoue = true;

        talkTextIndex = 0;
        talkText.text = talkingStrings[talkTextIndex];

        talkPrompt.SetActive(true);

        nPCController.StopMoving();
    }

    private void ProgressDialogue()
    {
        talkTextIndex++;
        talkText.text = talkingStrings[talkTextIndex];
    }

    private void EndDialogue()
    {
        showingDialgoue = false;
        talkPrompt.SetActive(false);
        nPCController.ContinueMoving();
    }

    public virtual bool IsWithinDistance(float distance)
    {
        return (GetDirection().magnitude < distance);
    }

    public virtual Vector3 GetDirection()
    {
        return target.position - transform.position;
    }
}
