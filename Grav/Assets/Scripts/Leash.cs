using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leash : MonoBehaviour {

    public float DestroyRadius = 50f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gameObject.transform.position.magnitude >= DestroyRadius)
        {
            Destroy(gameObject);
        }
	}
}
