using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class objectControl : simpleController
{
    private Vector3 center;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        
        center = transform.position;
    }

    void FixedUpdate()
    {
        gameObject.transform.position = center;

        if (check)
        {
            rb.constraints = RigidbodyConstraints.None;
            
        }

        else
        {
            rb.AddForce(-rb.velocity);
            rb.velocity = Vector3.zero;
            Debug.Log("Attached");
            ////GetComponent<Rigidbody>().freezeRotation = true;

            rb.constraints = RigidbodyConstraints.FreezeAll;

        }
    }
}
