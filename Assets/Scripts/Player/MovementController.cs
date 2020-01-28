using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody thisRB;
    Animator thisAnim;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        thisRB = GetComponent<Rigidbody>();
        thisAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        thisRB.velocity = 
            Vector3.Lerp(thisRB.velocity, 
                (((Input.GetAxis("Horizontal") * transform.right) + (Input.GetAxis("Vertical") * transform.forward)) * speed) + Physics.gravity, 0.5f);
        thisRB.velocity = Vector3.ClampMagnitude(thisRB.velocity, speed / 2);
        thisAnim.SetFloat("Velocity", Mathf.Abs(thisRB.velocity.x) + Mathf.Abs(thisRB.velocity.z));
    }
}
