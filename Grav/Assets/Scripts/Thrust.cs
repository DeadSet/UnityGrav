using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour {

    public float ThrustMagnitude = 1f;
    public float TurnGain = 1f;

    private Rigidbody rb;
    private bool ThrustRequest = false;
    //private float TorqueRequest;
    //private bool TurnRequest = false;
    private int rayTarget;
    private float rayLength = 1000f;


	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody>();
        rayTarget = LayerMask.GetMask("RayTarget");
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
/*
        if (Mathf.Abs(Input.GetAxis("Horizontal")) >= .1f)
        {
            TorqueRequest = Input.GetAxis("Horizontal");
            TurnRequest = true;

        }
        else
        {
            TurnRequest = false;
        }
*/
	}

    private void FixedUpdate()
    {
        if (ThrustRequest)
        {
            rb.AddRelativeForce(Vector3.up * ThrustMagnitude); 
        }
        /*
        if (TurnRequest)
        {
            rb.transform.Rotate(TorqueRequest * Time.deltaTime * TurnGain, 0, 0, Space.Self);
        }
        */

        Turn();
    }

    void Turn()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.Log(Input.mousePosition);
        

        if (Physics.Raycast(ray, out hit, rayLength, rayTarget, QueryTriggerInteraction.Collide))
        {
            Vector3 thisToMouse = hit.point - transform.position;
            thisToMouse.y = 0f;
            Debug.DrawLine(transform.position, thisToMouse);
            Quaternion newRotation = Quaternion.LookRotation(thisToMouse);
            rb.MoveRotation(newRotation);
        }
        Debug.Log(Physics.Raycast(ray, out hit, rayLength, rayTarget, QueryTriggerInteraction.Collide));
    }
}
