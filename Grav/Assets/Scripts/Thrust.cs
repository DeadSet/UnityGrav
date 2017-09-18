using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrust : MonoBehaviour {

    public float ThrustMagnitude = 1f;
    public float TurnGain = 1f;
    public GameObject Projectile;
    public float FireForce;

    private Rigidbody rb;
    private bool ThrustRequest = false;
    private int rayTarget;
    private float rayLength = 1000f;
    private bool fireReady = true;


	
	void Start () {     // when this was OnEnable only the first instance of the ship attracted. Other would, if toggled in inspector. 
        rb = GetComponent<Rigidbody>();
        rayTarget = LayerMask.GetMask("RayTarget");
     
        Gravity.orbitals.Add(rb);
        CameraControl.BeginCameraTracking();
     
        
	}
	
	
	void Update () {
        if (Input.GetButton("Fire2"))
        {
            ThrustRequest = true;
        }
        else
        {
            ThrustRequest = false;
        }

        if (Input.GetButton("Fire1") && fireReady)  
        {
            Fire();
            fireReady = false;
        }
       if (!Input.GetButton("Fire1"))
        {
            fireReady = true;
        }
        

	}

    private void FixedUpdate()
    {
        if (ThrustRequest)
        {
            rb.AddRelativeForce(Vector3.forward * ThrustMagnitude); 
        }
        

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

    void Fire()
    {
        Transform firelocation = transform;
        GameObject Spawned = Instantiate(Projectile, transform.position, transform.rotation);
        Rigidbody SpawnedRB = Spawned.GetComponent<Rigidbody>();
        SpawnedRB.velocity = rb.velocity;
        SpawnedRB.AddRelativeForce(Vector3.forward * FireForce);
        rb.AddRelativeForce(Vector3.back * FireForce);
    
        
    }
}
