using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchArrayController : MonoBehaviour
{
    public SwitchController[] switches;
    public DoorController unlocker;
    private bool unlocked;
    private int index;

    private void Awake()
    {
        index = 0;
        unlocked = false;
    }

    public void ActivateSwitch(SwitchController s)
    {
        if(switches[index] == s.GetComponent<SwitchController>())
        {
            index += 1;
            if (index == switches.Length - 1)
            {
                unlocker.Unlock();
                unlocked = true;
            }
        } else
        {
            index = 0;
        }
    }
}
