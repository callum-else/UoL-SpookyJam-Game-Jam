using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    AudioSource thisSource;

    public AudioClip footstep;

    private void Awake()
    {
        thisSource = GetComponent<AudioSource>();
    }

    public void PlayFootstep()
    {
        thisSource.PlayOneShot(footstep);
    }
}
