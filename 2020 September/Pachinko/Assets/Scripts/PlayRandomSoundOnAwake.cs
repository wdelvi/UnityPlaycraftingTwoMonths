using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioRandomizer))]
public class PlayRandomSoundOnAwake: MonoBehaviour
{
    public List<AudioClip> possibleSounds;

    private AudioRandomizer audioRandomizer;

    // Start is called before the first frame update
    void Start()
    {
        audioRandomizer = GetComponent<AudioRandomizer>();
        PlayRandomSound();
    }

    public void PlayRandomSound()
    {
        audioRandomizer.PlayRandomSound(possibleSounds);
    }
}
