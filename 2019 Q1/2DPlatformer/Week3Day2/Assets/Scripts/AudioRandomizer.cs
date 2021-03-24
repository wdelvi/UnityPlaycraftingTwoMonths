using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour 
{
    private AudioSource audioSource;

	void Start () 
    {
        audioSource = GetComponent<AudioSource>();	
	}

    public void PlayRandomSound( List<AudioClip> audioClips )
    {
        if(audioClips.Count <= 0)
        {
            return;
        }

        int clipIndex = Random.Range(0, audioClips.Count);
        AudioClip clipToPlay = audioClips[clipIndex];
        audioSource.clip = clipToPlay;
        audioSource.Play();
    }
}
