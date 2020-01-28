using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(InteractableController))]
[RequireComponent(typeof(AudioSource))]
public class DoorController : MonoBehaviour
{
    Animator thisAnim;
    AudioSource thisAudio;
    InteractableController iController;
    public Animator displayText;
    Text textElement;
    public PlayerHandManager phManager;
    private bool doorOpen = false;
    public bool locked = true;
    public GameObject key;

    public void PlayDoorSwing()
    {
        thisAudio.Play();
    }

    private void Start()
    {
        iController = GetComponent<InteractableController>();
        thisAnim = GetComponentInParent<Animator>();
        textElement = displayText.GetComponent<Text>();
    }

    public void Unlock()
    {
        locked = false;
    }

    private void OnMouseDown()
    {
        if(locked && phManager.heldController != null && phManager.heldController.gameObject == key)
        {
            Unlock();
            phManager.DestroyHeldItem();
            textElement.text = "Unlocked.";
            displayText.SetTrigger("Display");
        } else if (!locked && iController.inRange)
        {
            thisAnim.SetTrigger(doorOpen ? "Door-Close" : "Door-Open");
            doorOpen = doorOpen ? false : true;
        } else
        {
            textElement.text = "Locked.";
            displayText.SetTrigger("Display");
        }
    }
}
