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
    private float zoomSpeed;
    


	// Use this for initialization
	void Awake () {
        gameCamera = GetComponent<Camera>();
        playerShip = GameObject.FindWithTag("Player"); 
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Zoom();
		
	}

    private void Zoom()
    {
        float newSize = FindNewSize();
        gameCamera.orthographicSize = Mathf.SmoothDamp(gameCamera.orthographicSize, newSize, ref zoomSpeed, dampTime);
    }

    private float FindNewSize()
    {
        float size = 0f;

        size = Mathf.Max(size, Mathf.Abs(playerShip.transform.position.y));
        size = Mathf.Max(size, Mathf.Abs(playerShip.transform.position.x / gameCamera.aspect));

        size += ScreenEdgeBuffer;

        size = Mathf.Clamp(size, MinSize, MaxSize);

        return size;
    }
}
