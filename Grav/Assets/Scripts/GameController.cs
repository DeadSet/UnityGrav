using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject playerShip;
    public Vector3 startingForce;
    public Vector3 spawnPosition;


	// Use this for initialization
	void Start () {

        GameObject spawned = Instantiate(playerShip, spawnPosition, Quaternion.identity);
        Rigidbody spawnedRB = spawned.GetComponent<Rigidbody>();
        spawnedRB.AddForce(startingForce);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
