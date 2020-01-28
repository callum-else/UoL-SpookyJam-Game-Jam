using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform thisBody;
    public Transform thisCam;
    public float camMin, camMax;
    private float pitch;
    // Start is called before the first frame update
    void Start()
    {
        pitch = thisCam.eulerAngles.x;
        thisBody = thisCam.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Set Horizontal Rotation
        thisBody.rotation = Quaternion.Euler(0, thisBody.eulerAngles.y + Input.GetAxis("Mouse X"), 0);

        //Set Vertical Rotation
        pitch = Mathf.Clamp(pitch - Input.GetAxis("Mouse Y"), camMin, camMax);
        thisCam.localRotation = Quaternion.Euler(pitch, 0, 0);
        //thisCam.localEulerAngles = new Vector3(Mathf.Clamp(thisCam.localEulerAngles.x, camMin, camMax), 0, 0);
    }
}
