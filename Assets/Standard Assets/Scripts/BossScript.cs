using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{


	private ScaleBossScript getBossScript;
	private AbosrbScript getAsorbScript;
	private DestroyThisObject getDestroyScript;
	private StageArea getStageAreaScript;
	private bool stage1, stage2, stage3, activate, canJump;
	private int count, jumpCount = 0;

	// Use this for initialization
	void Start ()
	{
		stage1 = stage2 = stage3 = activate = false;
		canJump = true;
		getBossScript = GameObject.Find ("ScaleBoss").GetComponent<ScaleBossScript> ();
		getAsorbScript = GameObject.Find ("Mine").GetComponent<AbosrbScript> ();
		getDestroyScript = GameObject.Find ("FirstBattleArea").GetComponent<DestroyThisObject> ();
		getStageAreaScript = GameObject.Find ("StageAreaManager").GetComponent<StageArea> ();


	}
	
	// Update is called once per frame
	void Update ()
	{

		if ((stage1 || stage2 || stage3 && getBossScript.speed == 0) && activate) {

			//Activate stage boss fight
			ActivateStage ();
			Debug.Log ("Why!! Is this thing ReUpdating!!");
		}
	}

	//NEED TO DESTROY COLLISION BOX OF THE OTHER OBJECT SO IT WONT CALL AND ACTIVATE STAGE AGAIN
	void OnTriggerEnter (Collider col)
	{

		if (col.gameObject.name == "FirstBattleArea") {
			getBossScript.canSlow = true;
			stage1 = true;
			activate = true;
			getDestroyScript.RemoveObject();
		}
	}

	void ActivateStage ()
	{
		if (stage1 && getBossScript.speed == 0) {
			StartCoroutine (StageOneFight ());
			Debug.Log ("Why!! Activate Stage");
			activate = false;
		}
	}

	IEnumerator StageOneFight ()
	{
		//First boss jump
		getAsorbScript.canDraw = false;

		Jump ();
		Debug.Log ("dude");
		jumpCount++;
		yield return new WaitForSeconds (7f);

		getAsorbScript.canDraw = true;
		Debug.Log ("eerste waitfor");
		yield return new WaitForSeconds (3f);

		//Following boss jumps
		Debug.Log ("Waited 10 seconds");
		if (jumpCount <= 3) {
			StartCoroutine (StageOneFight ());
		}

	}
	
	void Jump ()
	{
		if (canJump ) {
			StartCoroutine (getBossScript.JumpTween ());
			//canJump = false;
		}
	}
}
