using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject playerShip;
    public Vector3 startingForce;
    public Vector3 spawnPosition;
    //for testing
    public bool spawnThreat;
    public GameObject Threat;


	// Use this for initialization
	void Start () {

        GameObject spawned = Instantiate(playerShip, spawnPosition, Quaternion.identity);
        Rigidbody spawnedRB = spawned.GetComponent<Rigidbody>();
        spawnedRB.AddForce(startingForce);
	}
	
	// Update is called once per frame
	void Update () {

        if (spawnThreat)
        {
            Instantiate(Threat, new Vector3(20f, 0f, 0f), Quaternion.identity);
            spawnThreat = false;
        }
        
		
	}
}
