using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform target;
	public float AdjustedCameraDistance = 30.0f;
	public float AdjustedCameraHeight = 15.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(0.0f, AdjustedCameraHeight, -AdjustedCameraDistance);
	}
}
