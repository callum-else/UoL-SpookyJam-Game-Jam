using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAudioManager : MonoBehaviour
{
    public AudioSource elevatorDoor;
    public AudioSource playerAudio;
    public AudioSource rumbler;

    public void PlayRumbler()
    {
        rumbler.Play();
    }

    public void PlayElevatorDoor()
    {
        elevatorDoor.Play();
    }

    public void StartAmbience()
    {
        playerAudio.Play();
    }
}
