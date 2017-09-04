using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour {

    public float ThrustMagnitude = 1f;

    private Rigidbody rb;
    private bool ThrustRequest = false;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            ThrustRequest = true;
        }
        else
        {
            ThrustRequest = false;
        }
	}

    private void FixedUpdate()
    {
        if (ThrustRequest)
        {
            rb.AddForce(Vector3.left * ThrustMagnitude);
        }
    }
}
