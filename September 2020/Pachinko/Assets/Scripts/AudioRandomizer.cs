using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioRandomizer : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayRandomSound( List<AudioClip> possibleSounds )
    {
        if( possibleSounds.Count == 0 )
        {
            return;
        }

        int randomSoundIndex = Random.Range(0, possibleSounds.Count);

        AudioClip soundToPlay = possibleSounds[randomSoundIndex];

        audioSource.PlayOneShot(soundToPlay);
    }
}
