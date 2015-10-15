using UnityEngine;
using System.Collections;

public class AbosrbScript : MonoBehaviour
{

	public Transform other, target;
	public float dist, speed, distStage, step, oldSpeed;
	public float scalar;
	public bool canDraw;
	private ScaleBossScript getScaleScript;
	private GameObject bossLocation;


	// Use this for initialization
	void Start ()
	{
		oldSpeed = speed;
		step = speed * Time.deltaTime;
		scalar = 1.2f;
		canDraw = true;
		getScaleScript = GameObject.Find("ScaleBoss").GetComponent<ScaleBossScript>();
		bossLocation = GameObject.Find ("ScaleBoss");
		other = bossLocation.transform;
		target = bossLocation.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (other) {
			dist = Vector3.Distance (other.position, transform.position);
			distStage = Vector3.Distance (other.position, transform.position);	//Other draw
		}

		//Initiate drawing of nearby objects
		if (dist <= 13f && canDraw || (distStage <= 15f && canDraw)) {
			DrawObject ();
			StageDraw ();
		}

		//destroy objects that hit me and increase the impact range
		if (dist <= (5f * scalar)) {
			step = 0;
			getScaleScript.scaleUp = true;
			getScaleScript.ScaleBoss ();
			speed = 0;
			scalar++;
			Destroy (gameObject);
		}
	}

	void DrawObject ()
	{
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);
		//speed += 0.1f;
	}

	public void StageDraw ()
	{
		transform.position = Vector3.MoveTowards (transform.position, other.transform.position, step);
	}

	void OnTriggerEnter ()
	{

	}

}
