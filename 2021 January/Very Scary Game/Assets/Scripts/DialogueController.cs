using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    public float minTalkDistance;
    public Transform playerTransform;
    public Text dialogueText;
    public GameObject dialoguePrompt;
    [TextArea(15, 20)]
    public List<string> dialogueStrings;

    private int talkTextIndex;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawWireSphere(transform.position, minTalkDistance);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialoguePrompt.SetActive(false);
        talkTextIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform != null)
        {
            if (GetWithinDistance(minTalkDistance, playerTransform.position))
            {
                DetectInput();
            }
            else if(dialoguePrompt.activeSelf)
            {
                EndDialogue();
            }
        }
    }

    private void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(dialoguePrompt.activeSelf == false)
            {
                BeginDialogue();
            }
            else if( talkTextIndex < dialogueStrings.Count - 1 )
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
        dialogueText.text = dialogueStrings[talkTextIndex];
        dialoguePrompt.SetActive(true);
    }

    private void ProgressDialogue()
    {
        talkTextIndex++;
        dialogueText.text = dialogueStrings[talkTextIndex];
    }

    private void EndDialogue()
    {
        dialoguePrompt.SetActive(false);
        talkTextIndex = 0;
    }

    protected bool GetWithinDistance(float maxDistance, Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - transform.position;

        return (directionToTarget.magnitude <= maxDistance);
    }
}