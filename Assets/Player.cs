using UnityEngine;
using System.Collections;

public class Player: MonoBehaviour {
	
	//Variables
	public float PaddleSpeed = 10f;//Paddle movement speed
	
	public GameObject PaddleBall;//link to Game Ball
	GameObject attachedBall = null;//local variable to contain PaddleBall link

	
	//for game speed manipulation
	public float InAirXmovement = 300f;
	public float InAirYmovement = 300f;
	public float PaddleHitMovement = 300f;
	
	// Use this for initialization
	void Start () 
	{
		
		SpawnBall ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		Movement ();
		
		
		
		
	}
	void FixedUpdate() 
	{
		
	}
	
	void LateUpdate() 
	{

	}
	
	public void LoseLife()
	{
		SpawnBall ();
	}
	/*****************************
	 * function to Spawn the ball*
	 ****************************/
	void SpawnBall()
	{
		//Local Gameobject Attached ball has the starting position.		
		attachedBall = (GameObject)Instantiate (PaddleBall,transform.position + new Vector3(0,0.5f,0),Quaternion.identity);
	}
	/******************************
	 * function handling movement *
	 * AND boundaries			  *
	 *****************************/
	void Movement()
	{
		transform.Translate (PaddleSpeed * Time.deltaTime * Input.GetAxis ("Horizontal"),0,0);
		
		if ( transform.position.x > 8.4f )
		{
			transform.position = new Vector3( 8.4f, transform.position.y, transform.position.z );
		}
		if ( transform.position.x < -8.4f ) 
		{
			transform.position = new Vector3( -8.4f, transform.position.y, transform.position.z );
		}
		/************************************************************************* 
		 * Make a call to the rigidbody of the Ball								 *
		 * Make sure that the update of the ball is constantly at the start point*
		 *************************************************************************/
		if(attachedBall)
		{
			Rigidbody ballRigidbody = attachedBall.rigidbody;
			ballRigidbody.position = transform.position + new Vector3(0,.5f,0);
			
			if(Input.GetButtonDown ("LaunchBall"))
			{
				ballRigidbody.isKinematic = false;
				ballRigidbody.AddForce(InAirXmovement * Input.GetAxis ("Horizontal"), InAirYmovement,0);
				//the first coordinate is how fast it moves in the X axis, second coordinate is how fast it moves in Y axis.
				attachedBall = null;
				
				
			}
		}
	}
	/************************************************
	 * Dealing with what happens when the ball hits *
	 * the paddle after initial launch				*
	 ***********************************************/
	void OnCollisionEnter( Collision col ) {
		foreach (ContactPoint contact in col.contacts) {
			if( contact.thisCollider == collider ) {
				// This is the paddle's contact point
				float DifferenceLocation = contact.point.x - transform.position.x;
				
				contact.otherCollider.rigidbody.AddForce( PaddleHitMovement * DifferenceLocation, 0, 0);
				//how much force is added to paddle when position is favoring left or right.
			}
		}
	}
	
	
	
}