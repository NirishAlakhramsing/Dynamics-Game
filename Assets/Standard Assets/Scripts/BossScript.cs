using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour {


	private ScaleBossScript getBossScript;
	private AbosrbScript getAsorbScript;
	private bool stage1, stage2, stage3, canJump;
	private Vector3 position;

	// Use this for initialization
	void Start () {
		stage1 = stage2 = stage3 = false;
		canJump = true;
		getBossScript = GameObject.Find ("ScaleBoss").GetComponent<ScaleBossScript> ();
		getAsorbScript = GameObject.Find ("Mine").GetComponent<AbosrbScript> ();

		position = new Vector3 (0, 2f, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (stage1 || stage2 || stage3 && getBossScript.speed == 0) {
			//Activate stage boss fight
			ActivateStage();
		}
	}

	void OnTriggerEnter (Collider col){

		if (col.gameObject.tag == "Boss" && gameObject.name == "FirstBattleArea") {
			getBossScript.canSlow = true;
			Debug.Log (getBossScript.speed);
			stage1 = true;
		}
	}

	void ActivateStage (){
		if (stage1 && getBossScript.speed == 0) {
			getAsorbScript.canDraw = false;
			Jump();
		}
	}
	
	void Jump(){
		//position = new Vector3 (transform.position.x, 20f, transform.position.z);
		//transform.position = position;
		//iTween.MoveBy (gameObject, new Vector3(0,10f,0), 3f);
		//Debug.Log ("JUMPED");
		if (canJump) {
			StartCoroutine(getBossScript.Jump ());
			canJump = false;
		}
	}
}
