using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject playerShip;
    public Vector3 startingForce;
    public Vector3 spawnPosition;
    public float spawnRingRadius;
    //for testing
    public bool RequestThreat;
    public GameObject Threat;


	// Use this for initialization
	void Start () {

        GameObject spawned = Instantiate(playerShip, spawnPosition, Quaternion.identity);
        Rigidbody spawnedRB = spawned.GetComponent<Rigidbody>();
        spawnedRB.AddForce(startingForce);
	}
	
	// Update is called once per frame
	void Update () {

        if (RequestThreat)
        {
            SpawnThreat();
            RequestThreat = false;
        }
        
		
	}

    void SpawnThreat()
    {
        float x;
        float y;

        x = Random.Range(-spawnRingRadius, spawnRingRadius);
        y = Mathf.Sqrt(Mathf.Pow(spawnRingRadius, 2f) - Mathf.Pow(x, 2f));
        y = y *(Random.Range(0, 1) * 2 - 1); //returns 1 or -1, y will allways start positive
        Instantiate(Threat, new Vector3(x, 0f, y), Quaternion.identity);
    }
}
