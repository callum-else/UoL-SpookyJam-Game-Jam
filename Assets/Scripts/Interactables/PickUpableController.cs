using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InteractableController))]
public class PickUpableController : MonoBehaviour
{
    public PlayerHandManager playerHand;
    InteractableController iController;
    Transform thisParent;
    Rigidbody thisRB;
    
    public bool isHeld = false;
    public Vector3 targetPos;

    private void Awake()
    {
        iController = GetComponent<InteractableController>();
        thisRB = GetComponent<Rigidbody>();
        thisParent = transform.parent;
    }

    private void FixedUpdate()
    {
        if (thisRB.isKinematic)
        {
            if (transform.localPosition != targetPos)
                transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos, 0.1f);
            else if (transform.localPosition == targetPos && !isHeld)
                thisRB.isKinematic = false;
        }
    }

    private void OnMouseDown()
    {
        if (iController.inRange)
            playerHand.PickUpObject(transform);
    }

    public void PutDown(Vector3 position)
    {
        targetPos = position;
        isHeld = false;
        transform.parent = thisParent;
    }

    public void PickUp(Transform target)
    {
        transform.parent = target;
        targetPos = Vector3.zero;
        thisRB.isKinematic = true;
        isHeld = true;
    }
}
