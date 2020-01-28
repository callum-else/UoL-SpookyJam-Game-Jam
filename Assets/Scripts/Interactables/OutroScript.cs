using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutroScript : MonoBehaviour
{

    Animator thisAnim;
    public Animator boxAnim;
    public Animator elivatorAnim;

    private void Awake()
    {
        thisAnim = GetComponentInParent<Animator>();
    }

    private void OnMouseDown()
    {
        thisAnim.SetTrigger("Activate");
        boxAnim.SetTrigger("Door-Close");
        boxAnim.GetComponentInChildren<DoorController>().locked = true;
        elivatorAnim.SetTrigger("GameOver");
    }

}
