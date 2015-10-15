using UnityEngine;
using System.Collections;

public class ScaleBossScript : MonoBehaviour
{

	public float scaleFactor = 0.1f;
	public float speed;
	public bool scaleUp, scaleDown;
	private StageArea getStageAreaScript;
	private BossScript getBossScript;
	Rigidbody rigidB;
	

	// Use this for initialization
	void Start ()
	{
		rigidB = GameObject.Find ("Boss").GetComponent<Rigidbody> ();
		getStageAreaScript = GameObject.Find ("StageAreaManager").GetComponent<StageArea> ();
		getBossScript = GameObject.Find ("Boss").GetComponent<BossScript> ();
		scaleUp = scaleDown = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		ScaleBoss ();
	}

	//SCALE BOSS UP OR DOWN
	public void ScaleBoss ()
	{
		if (Input.GetKeyDown ("r") || scaleUp) {
			transform.localScale += new Vector3 (scaleFactor, scaleFactor, scaleFactor);
			getBossScript.speed -= 0.1f;
			scaleUp = false;
		}
		
		if (Input.GetKeyDown ("t") || scaleDown) {
			transform.localScale -= new Vector3 (scaleFactor, scaleFactor, scaleFactor);
			getBossScript.speed += 0.1f;
		}
	}
	
}
