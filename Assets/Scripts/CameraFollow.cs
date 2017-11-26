using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	Camera cam;
	//public static CameraFollow cFollow;
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;
	//public Transform target;
	public float MidpointX;
	public float MidpointY;
	public float MidpointZ;
	public Transform Player1;
	public Transform Player2;
	public Vector3 MidpointXYZ;
	public Vector3 distance;
	public float cameraDistance;
	public float CameraOffset;
	public float boundaries;

	void Awake () 
	{
		cam = GetComponent<Camera> ();

	}

	// Use this for initialization
	void Start () 
	{
		cameraDistance = 54.0f;
		boundaries = 37.0f;
	}

    // Update is called once per frame
    void Update()
    {
        distance = Player1.position - Player2.position;
        //if(camDistance >= 19.0f)
        //	camDistance = 19.0f;
        if (cameraDistance <= 10.0f)
            cameraDistance = 10.0f;
        if (distance.x < 0)
            distance.x = distance.x * -1;
        if (distance.z < 0)
            distance.z = distance.z * -1;
        if (Player1.position.x < (transform.position.x - boundaries))
        {
            Vector3 pos = Player1.position;
            pos.x = transform.position.x - boundaries;
            Player1.position = pos;
        }
        if (Player2.position.x < (transform.position.x - boundaries))
        {
            Vector3 pos = Player2.position;
            pos.x = transform.position.x - boundaries;
            Player2.position = pos;
        }
        if (Player1.position.x > (transform.position.x + boundaries))
        {
            Vector3 pos = Player1.position;
            pos.x = transform.position.x + boundaries;
            Player1.position = pos;
        }
        if (Player2.position.x > (transform.position.x + boundaries))
        {
            Vector3 pos = Player2.position;
            pos.x = transform.position.x + boundaries;
            Player2.position = pos;
        }
        if (distance.x > 15.0f)
        {
            CameraOffset = distance.x * 0.3f;
            if (CameraOffset >= 8.5f)
                CameraOffset = 8.5f;
        }
        else if (distance.x < 14.0f)
        {
            CameraOffset = distance.x * 0.3f;
        }
        else if (distance.z < 14.0f)
        {
            CameraOffset = distance.x * 0.3f;
        }
        MidpointX = (Player2.position.x + Player1.position.x) / 2;
        MidpointY = (Player2.position.y + Player1.position.y) / 2;
        MidpointZ = (Player2.position.z + Player1.position.z) / 2;
        MidpointXYZ = new Vector3(MidpointX, MidpointY, MidpointZ);
        if (Player1 && Player2)
        {
            Vector3 point = cam.WorldToViewportPoint(MidpointXYZ);
            Vector3 delta = MidpointXYZ - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, cameraDistance + CameraOffset)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }
        else
        {
            Debug.Log(" Player 1 or 2 does not exist!");
        }

    }
}
