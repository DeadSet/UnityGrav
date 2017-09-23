using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    private Rigidbody rb;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        Gravity.orbitals.Add(rb);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        HealthManager collided = other.GetComponent<HealthManager>();
        collided.ApplyDamage(1);
        Destroy(gameObject);
        
    }
}
