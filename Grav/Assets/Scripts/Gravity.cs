using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {

    //public Rigidbody objToAttract;
    public float G = 100f;


    private Rigidbody rb;
    public static List<Rigidbody> orbitals;
    
    // Use this for initialization
	void Awake () {

        rb = GetComponent<Rigidbody>();
        orbitals = new List<Rigidbody>();
   
        
		
	}
	
	// Update is called once per tick
	void FixedUpdate () {

        if (orbitals == null)
        {
            return;
        }
        else
        {
            foreach (Rigidbody orbital in orbitals)
            {
                Attract(orbital);
            }
        }
       
    
       
     
	}

    void Attract(Rigidbody objToAttract)
    {
        Rigidbody rbToAttract = objToAttract.GetComponent<Rigidbody>();

        Vector3 direction = rb.position - rbToAttract.position;
        float distance = direction.magnitude;

        float forceMagnitude = Time.deltaTime * G * (rb.mass * rbToAttract.mass) / Mathf.Pow(distance, 2);
        Vector3 force = direction.normalized * forceMagnitude;

        rbToAttract.AddForce(force);
        rbToAttract.drag = 1 / Mathf.Pow(distance, 2);
    }

    
}
