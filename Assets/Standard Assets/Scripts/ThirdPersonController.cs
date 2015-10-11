using UnityEngine;
using System.Collections;

public class ThirdPersonController : MonoBehaviour {

	[System.Serializable]
	public class MoveSettings
	{
		public float forwardVel = 12;
		public float rotateVel = 100;
		public float jumpVel = 25f;
		public float distToGrounded = 0.05f;
		public LayerMask ground;
	}
	
	[System.Serializable]
	public class PhysSettings
	{
		public float downAccel = 0.75f;
	}
	
	[System.Serializable]
	public class InputSettings
	{
		public float inputDelay = 0.1f;
		public string FORWARD_AXIS = "Vertical";
		public string TURN_AXIS = "Horizontal";
		public string JUMP_AXIS = "Jump";
	}
	
	public MoveSettings moveSetting = new MoveSettings ();
	public PhysSettings physSetting = new PhysSettings ();
	public InputSettings inputSetting = new InputSettings ();
	
	Vector3 velocity = Vector3.zero;
	Quaternion targetRotation;
	Rigidbody rBody;
	float forwardInput, turnInput, jumpInput, belowLevel, resetPosition;
	Vector3 position;
	
	public Quaternion TargetRotation{
		get { return targetRotation; }
	}
	
	bool Grounded()
	{
		return Physics.Raycast (transform.position, Vector3.down, moveSetting.distToGrounded, moveSetting.ground);
	}
	
	// Use this for initialization
	void Start () {
		targetRotation = transform.rotation;
		if (GetComponent<Rigidbody> ())
			rBody = GetComponent<Rigidbody> ();
		else
			Debug.LogError ("The character needs a rigidbody");
		
		forwardInput = turnInput = jumpInput = 0;


		belowLevel = -10f;
		resetPosition = 2f;

	}
	
	void GetInput(){
		forwardInput = Input.GetAxis (inputSetting.FORWARD_AXIS);
		turnInput = Input.GetAxis (inputSetting.TURN_AXIS);
		jumpInput = Input.GetAxisRaw (inputSetting.JUMP_AXIS);
	}
	
	// Update is called once per frame
	void Update () {
		GetInput ();
		Turn ();

		ResetPlayer ();
	}
	
	void FixedUpdate(){
		Run ();
		JumP ();
		
		rBody.velocity = transform.TransformDirection (velocity);
	}
	
	void Run(){
		if (Mathf.Abs (forwardInput) > inputSetting.inputDelay) {
			//Move
			velocity.z = moveSetting.forwardVel * forwardInput;
		}
		else
			velocity.z = 0;
	}
	
	void Turn(){
		if (Mathf.Abs (turnInput) > inputSetting.inputDelay) {
			targetRotation *= Quaternion.AngleAxis (moveSetting.rotateVel * turnInput * Time.deltaTime, Vector3.up);
		}
		transform.rotation = targetRotation;
	}
	
	void JumP(){
		if (jumpInput > 0 && Grounded ()) {
			//jump
			velocity.y = moveSetting.jumpVel;
		} else if (jumpInput == 0 && Grounded ()) {
			//zero out our velocity.y
			velocity.y = 0;
		} else {
			//decrease velocity.y
			velocity.y -= physSetting.downAccel;
		}
	}

	void ResetPlayer(){
		if (transform.position.y <= belowLevel) {
			position = new Vector3( transform.position.x, resetPosition, transform.position.z);
				transform.position = position;
		}
	}
}
