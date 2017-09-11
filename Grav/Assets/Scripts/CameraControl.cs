using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {


    public float dampTime = .2f;
    public float ScreenEdgeBuffer = 4f;
    public float MinSize = 20f;
    public float MaxSize = 80f;
    public GameObject playerShip;

    private Camera gameCamera;
    private float ZoomSpeed;
    


	// Use this for initialization
	void Awake () {
        gameCamera = GetComponent<Camera>();
        //playerShip = 
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Zoom();
		
	}

    private void Zoom()
    {
       
    }
}
