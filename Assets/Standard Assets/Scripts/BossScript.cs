﻿using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{

	private CameraController getCameraScript;
	private ScaleBossScript getScaleScript;
	private AbosrbScript getAsorbScript;
	private DestroyThisObject getDestroyScript;
	private StageArea getStageAreaScript;
	private bool stage1, stage2, stage3, activate, canJump, canSlow, canMove;
	private int count, jumpCount = 0;
	public float speed;
	Hashtable ht = new Hashtable ();

	void Awake ()
	{
		ht.Add ("y", 10f);
		ht.Add ("time", 3f);
		ht.Add ("delay", 2f);
		ht.Add ("looptype", iTween.LoopType.none);
	}

	// Use this for initialization
	void Start ()
	{
		stage1 = stage2 = stage3 = activate = canSlow = false;
		canJump = canMove = true;
		getScaleScript = GameObject.Find ("ScaleBoss").GetComponent<ScaleBossScript> ();
		getAsorbScript = GameObject.Find ("Mine").GetComponent<AbosrbScript> ();
		getDestroyScript = GameObject.Find ("FirstBattleArea").GetComponent<DestroyThisObject> ();
		getStageAreaScript = GameObject.Find ("StageAreaManager").GetComponent<StageArea> ();
		getCameraScript = GameObject.Find ("Main Camera").GetComponent<CameraController> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		MoveBoss ();//MOVE

		if (canSlow) {//SLOW DOWN
			SlowDownBoss ();
		}
		
		if (speed <= 0) {
			canSlow = false;//Stop Boss from moving away from standing position.
			speed = 0;
			canMove = false;//Make boss stop walking
		}

		if ((stage1 || stage2 || stage3 && speed == 0) && activate) {
			//Activate stage boss fight
			ActivateStage ();
		}
	}
	
	//MOVE BOSS
	public void MoveBoss ()
	{
		if (canMove) {
			transform.position += Vector3.forward * speed * Time.deltaTime;
			//transform.parent.position = transform.position - transform.localPosition;
			//rigidB.velocity = Vector3.forward * speed;
		}
	}

	//SLOW BOSS
	void SlowDownBoss ()
	{
		speed -= 0.005f;
	}

	//NEED TO DESTROY COLLISION BOX OF THE OTHER OBJECT SO IT WONT CALL AND ACTIVATE STAGE AGAIN
	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.name == "FirstBattleArea") {
			canSlow = true;
			stage1 = true;
			activate = true;
			getDestroyScript.RemoveObject ();
		}
	}
	
	void ActivateStage ()
	{
		if (stage1 && speed == 0) {
			StartCoroutine (StageOneFight ());
			activate = false;
		}
	}

	IEnumerator StageOneFight ()
	{
		//First boss jump
		getAsorbScript.canDraw = false;

		Jump ();
		jumpCount++;
		yield return new WaitForSeconds (7f);

		getAsorbScript.canDraw = true;
		yield return new WaitForSeconds (3f);

		//Following boss jumps
		Debug.Log ("Waited 10 seconds");
		if (jumpCount <= 3) {
			StartCoroutine (StageOneFight ());
		}
	}
	
	void Jump ()
	{
		if (canJump) {
			StartCoroutine (JumpTween ());
			//canJump = false;
		}
	}

	//Activates Jumptween and calls to pound mines out of the ground.
	public IEnumerator JumpTween ()
	{
		iTween.MoveBy (gameObject, ht);
		yield return new WaitForSeconds (3.5f);
		Debug.Log ("JUMPED");
		
		getCameraScript.ShakeCamera ();
		yield return new WaitForSeconds (1f);
		getStageAreaScript.startSpawning = true;
	}
}
