using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandManager : MonoBehaviour
{
    Transform heldObj = null;
    public PickUpableController heldController = null;
    public Transform thisHand;
    Animator thisAnim;

    private void Awake()
    {
        thisAnim = GetComponentInParent<Animator>();
    }

    public void PickUpObject(Transform obj)
    {
        if (heldObj != null)
            heldController.PutDown(obj.position);

        heldObj = obj;
        heldController = heldObj.GetComponent<PickUpableController>();
        heldController.PickUp(thisHand);
    }

    public void PutDownObject(Vector3 point)
    {
        heldController.PutDown(point);
        heldObj = null;
        heldController = null;
    }

    public void DestroyHeldItem()
    {
        thisAnim.SetTrigger("Destroy");
    }

    public void DestroyItemObect()
    {
        if(heldObj != null)
            Destroy(heldObj.gameObject);
    }
}
