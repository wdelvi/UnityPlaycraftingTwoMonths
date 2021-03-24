using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioRandomizer))]
public class PlayRandomSoundOnCollision : MonoBehaviour
{
    public List<AudioClip> possibleSounds;

    private AudioRandomizer audioRandomizer;

    // Start is called before the first frame update
    void Start()
    {
        audioRandomizer = GetComponent<AudioRandomizer>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        audioRandomizer.PlayRandomSound(possibleSounds);
    }
}
