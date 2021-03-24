using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour 
{
    private AudioSource audioSource;

	// Use this for initialization
	void Start () 
    {
        audioSource = GetComponent<AudioSource>();	
	}
	
    public void PlayRandomSound( List<AudioClip> possibleClips )
    {
        if( audioSource == null || possibleClips.Count <= 0 )
        {
            return;
        }

        AudioClip clipToPlay = possibleClips[ Random.Range( 0, possibleClips.Count ) ];
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }
}
