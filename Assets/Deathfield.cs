using UnityEngine;
using System.Collections;

public class Deathfield : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		BallScript ballscript = other.GetComponent<BallScript>();

		if(ballscript)
		{
			ballscript.Die();
		}
	}
}
