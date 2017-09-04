using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    public Rigidbody objToAttract;
    public float G = 100f;


    public Rigidbody rb;
   
    
    
    // Use this for initialization
	void Awake () {

      
        
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Attract(objToAttract);
	}

    void Attract(Rigidbody objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.GetComponent<Rigidbody>();

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = Time.deltaTime * G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
    }
}
