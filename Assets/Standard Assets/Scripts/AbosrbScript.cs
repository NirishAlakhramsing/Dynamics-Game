using UnityEngine;
using System.Collections;

public class AbosrbScript : MonoBehaviour {

	public Transform other, target;
	public float dist, speed;
	public bool canDraw;
	private ScaleBossScript getBossScript;

	// Use this for initialization
	void Start () {
		canDraw = true;
		getBossScript = GameObject.Find ("ScaleBoss").GetComponent<ScaleBossScript> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (other) {
			dist = Vector3.Distance(other.position, transform.position);
			//print ("Distance " + dist);
		}


		if (dist <= 13f && canDraw) {
			DrawObject();
		}

		if (dist <= 3f) {
			getBossScript.scaleUp = true;
			getBossScript.ScaleBoss();
			Destroy(gameObject);
		}
	}

	void DrawObject(){
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		speed += 0.1f;
	}

}
