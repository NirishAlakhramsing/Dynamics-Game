using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {


	private ScaleBossScript getBossScript;
	private AbosrbScript getAsorbScript;
	private bool stage1, stage2, stage3, activate, canJump;
	private int count = 0;

	// Use this for initialization
	void Start () {
		stage1 = stage2 = stage3 = activate = false;
		canJump = true;
		getBossScript = GameObject.Find ("ScaleBoss").GetComponent<ScaleBossScript> ();
		getAsorbScript = GameObject.Find ("Mine").GetComponent<AbosrbScript> ();


	}
	
	// Update is called once per frame
	void Update () {

		if ((stage1 || stage2 || stage3 && getBossScript.speed == 0) && activate) {

			//Activate stage boss fight
			ActivateStage();
			Debug.Log ("Why!! Is this thing ReUpdating!!");
		}
	}

	//NEED TO DESTROY COLLISION BOX OF THE OTHER OBJECT SO IT WONT CALL AND ACTIVATE STAGE AGAIN
	void OnTriggerEnter (Collider col){

		if (col.gameObject.tag == "Boss" && gameObject.name == "FirstBattleArea") {
			getBossScript.canSlow = true;
			Debug.Log ("Why!! ON trigger ENter");
			stage1 = true;
			activate = true;
		}
	}

	void ActivateStage (){
		if (stage1 && getBossScript.speed == 0) {
			StartCoroutine(StageOneFight());
			Debug.Log ("Why!! Activate Stage");
			activate = false;
		}

	}

	IEnumerator StageOneFight(){
		getAsorbScript.canDraw = false;
		Jump();
		Debug.Log ("dude");

		yield return new WaitForSeconds (10f);
		Debug.Log ("Waited 10 seconds");
		canJump = true;
		Jump ();
		//count++;

	}
	
	void Jump(){
		if (canJump) {
			StartCoroutine(getBossScript.Jump ());
			canJump = false;
		}
	}
}
