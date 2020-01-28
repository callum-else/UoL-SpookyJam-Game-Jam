using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour
{

    Animator thisAnim;
    public bool single = true;
    public DoorController unlocker;
    public SwitchArrayController switchArray;
    bool unlocked;

    private void Awake()
    {
        thisAnim = GetComponentInParent<Animator>();
        unlocked = false;
    }

    private void OnMouseDown()
    {
        thisAnim.SetTrigger("Activate");
        if (single)
        {
            if (!unlocked && unlocker != null)
            {
                unlocker.Unlock();
                unlocked = true;
            }
        }
        else if(switchArray != null)
        {
            switchArray.ActivateSwitch(this);
        }

    }

}
