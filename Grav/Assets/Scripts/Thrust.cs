using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour {

    public float ThrustMagnitude = 1f;
    public float TurnGain = 1f;

    private Rigidbody rb;
    private bool ThrustRequest = false;
    private float TorqueRequest;
    private bool TurnRequest = false;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Jump"))
        {
            ThrustRequest = true;
        }
        else
        {
            ThrustRequest = false;
        }

        if (Mathf.Abs(Input.GetAxis("Horizontal")) >= .1f)
        {
            TorqueRequest = Input.GetAxis("Horizontal");
            TurnRequest = true;

        }
        else
        {
            TurnRequest = false;
        }
	}

    private void FixedUpdate()
    {
        if (ThrustRequest)
        {
            rb.AddRelativeForce(Vector3.up * ThrustMagnitude);
            
        }

        if (TurnRequest)
        {
            rb.transform.Rotate(TorqueRequest * Time.deltaTime * TurnGain, 0, 0, Space.Self);
        }
    }
}
