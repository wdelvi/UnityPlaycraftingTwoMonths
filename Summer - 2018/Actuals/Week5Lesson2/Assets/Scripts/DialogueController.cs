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
    public Animator dialogueAnimator;

    private int talkTextIndex;
    private bool showingDialogue;
    private NPCController nPCController;


	// Use this for initialization
	void Start () 
    {
        talkTextIndex = 0;
        showingDialogue = false;

        nPCController = GetComponent<NPCController>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if( target == null )
        {
            return;
        }

        float distanceToTalkTarget = ( target.position - transform.position ).magnitude;

        if( distanceToTalkTarget < minTalkDistance )
        {
            talkPrompt.SetActive( true );

            DetectInput();
        }
        else
        {
            talkPrompt.SetActive( false );

            if( showingDialogue )
            {
                EndDialogue();
            }
        }
	}

    private void DetectInput()
    {
        if( Input.GetKeyUp( KeyCode.T ) )
        {
            if( showingDialogue == false )
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
        showingDialogue = true;

        talkTextIndex = 0;
        talkText.text = talkingStrings[ talkTextIndex ];

        dialogueAnimator.SetTrigger( "Show" );

        nPCController.StopMoving();
    }

    private void ProgressDialogue()
    {
        talkTextIndex++;
        talkText.text = talkingStrings[ talkTextIndex ];
    }

    private void EndDialogue()
    {
        showingDialogue = false;

        dialogueAnimator.SetTrigger( "Hide" );

        nPCController.ContinueMoving();
    }

}
