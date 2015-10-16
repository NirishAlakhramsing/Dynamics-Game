using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {


	public Transform target;
	public float lookSmooth = 0.09f;
	public Vector3 offsetFromTarget = new Vector3(0, 6, -8);
	public float xTilt =10;

	Vector3 destination  = Vector3.zero;
	ThirdPersonController charController;
	float rotateVel = 0;

	Hashtable ht = new Hashtable();
	
	// Use this for initialization
	void Start () {

		ht.Add("x",3f);
		ht.Add("y",3f);
		ht.Add("z",3f);
		ht.Add("time",1f);
		ht.Add("looptype",iTween.LoopType.none);


		SetCameraTarget (target);
	}

	void SetCameraTarget(Transform t)
	{
		target = t;

		if (target != null) 
		{
			if (target.GetComponent<ThirdPersonController>())
			{
				charController = target.GetComponent<ThirdPersonController>();
			}
			else
			{
				Debug.LogError("The camaera target needs a characterController");
			}
		} else
			Debug.LogError ("Your camera needs a target");
	}


	void LateUpdate(){
		//moving
		MoveToTarget ();
		//rotating
		LookAtTarget ();
	}

	void MoveToTarget(){
		destination = charController.TargetRotation * offsetFromTarget;
		destination += target.position;
		transform.position = destination;
	}

	void LookAtTarget(){
		float eulerYAngle = Mathf.SmoothDampAngle (transform.eulerAngles.y, target.eulerAngles.y, ref rotateVel, lookSmooth);
		transform.rotation = Quaternion.Euler (transform.eulerAngles.x, eulerYAngle, 0);
	}

	public void ShakeCamera(){
		iTween.ShakeRotation (gameObject, ht);
	}
	
}
