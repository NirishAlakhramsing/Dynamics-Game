using UnityEngine;
using System.Collections;

public class ScaleBossScript : MonoBehaviour {

	public float scaleFactor = 0.1f;
	public float speed;
	public bool canSlow, scaleUp, scaleDown, canMove;
	private CameraController getCameraScript;

	Hashtable ht = new Hashtable();

	void Awake(){
		ht.Add("y",10f);
		ht.Add("time",3f);
		ht.Add("delay",2f);
		ht.Add("looptype",iTween.LoopType.none);
	}


	// Use this for initialization
	void Start () {
		getCameraScript = GameObject.Find ("Main Camera").GetComponent<CameraController> ();

		canSlow = scaleUp = scaleDown = false;
		canMove = true;
	}
	
	// Update is called once per frame
	void Update () {

		MoveBoss ();
		ScaleBoss ();

		if (canSlow) {
			SlowDownBoss();
		}

		if (speed <= 0) {
			canSlow = false;//Stop Boss from moving away from standing position.
			speed = 0;
			canMove = false;//Make boss stop walking
		}
	}
	
	public void ScaleBoss (){
		
		if (Input.GetKeyDown ("r") || scaleUp) {
			transform.localScale += new Vector3 (scaleFactor, scaleFactor, scaleFactor);
			speed -= 0.1f;
			scaleUp = false;
		}
		
		if (Input.GetKeyDown ("t") || scaleDown) {
			transform.localScale -= new Vector3 (scaleFactor, scaleFactor, scaleFactor);
			speed += 0.1f;
		}
	}

	void SlowDownBoss(){
		speed -= 0.005f;
	}

	public void MoveBoss(){

		if (canMove) {
			transform.position += Vector3.forward * speed * Time.deltaTime;
		}
	}

	public IEnumerator Jump(){
		//position = new Vector3 (transform.position.x, 20f, transform.position.z);
		//transform.position = position;
		iTween.MoveBy (gameObject, ht);
		yield return new WaitForSeconds (3.5f);
		Debug.Log ("JUMPED");
		getCameraScript.ShakeCamera ();
	}
}
