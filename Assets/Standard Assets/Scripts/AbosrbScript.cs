using UnityEngine;
using System.Collections;

public class AbosrbScript : MonoBehaviour {

	public Transform other, target;
	public float dist, speed, distStage;
	public int scalar;
	public bool canDraw;
	private ScaleBossScript getBossScript;
	private StageArea getStageAreaScript;
	private GameObject bossLocation;


	// Use this for initialization
	void Start () {
		scalar = 1;
		canDraw = true;
		getBossScript = GameObject.Find ("ScaleBoss").GetComponent<ScaleBossScript> ();
		bossLocation = GameObject.Find ("Boss");
		getStageAreaScript = GameObject.Find ("StageAreaManager").GetComponent<StageArea> ();

		other = bossLocation.transform;
		target = bossLocation.transform;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (other);

		if (other) {
			dist = Vector3.Distance(other.position, transform.position);
			distStage = Vector3.Distance(getBossScript.transform.position, transform.position);
			//print ("Distance " + dist);
		}

		//Initiate drawing of nearby objects
		if (dist <= 13f && canDraw || (distStage <= 15f && canDraw)) {
			DrawObject();
			StageDraw();
		}

		//destroy objects that hit me and increase the impact range
		if (dist <= (5f * scalar)) {
			getBossScript.scaleUp = true;
			getStageAreaScript.mineCount--;
			getBossScript.ScaleBoss();
			Destroy (gameObject);
			scalar++;
		}

	}

	void DrawObject(){
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		speed += 0.1f;
	}

	public void StageDraw(){
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, getBossScript.transform.position, step);
		speed += 0.1f;
	}

	void OnTriggerEnter(){


	}

}
