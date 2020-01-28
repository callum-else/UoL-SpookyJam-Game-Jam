using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookController : MonoBehaviour
{
    Transform thisCam;
    InteractableController lookAtObj;
    public float maxObjDist;

    private void Start()
    {
        thisCam = GetComponentInChildren<Camera>().transform;
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(thisCam.position, thisCam.forward);
        RaycastHit hit;
        Physics.Raycast(ray, out hit, maxObjDist);
        //Debug.Log(hit.collider ? hit.collider.name : "Not hit");
        if (hit.collider != null && hit.collider.tag == "Interactable")
        {
            lookAtObj = hit.collider.GetComponent<InteractableController>();
            lookAtObj.inRange = true;
        } else if(lookAtObj != null)
        {
            lookAtObj.inRange = false;
        }
    }
}
