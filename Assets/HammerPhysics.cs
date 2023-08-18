using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.drag = 0;
        rb.centerOfMass.Set(0.05713675f, 0.11f, -0.08f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 extraGravityForce = (Physics.gravity * 4) - Physics.gravity;
        rb.AddForce(extraGravityForce);


    }
}
