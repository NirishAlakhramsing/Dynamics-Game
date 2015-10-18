using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {

	public float speed, lifeTime;
    private ScaleBossScript getScaleScript;
 
    private Vector3 forward;

	// Use this for initialization
	void Start () {
        
        forward = transform.forward;
        forward.y = 0;
        float headingAngle = Quaternion.LookRotation(forward).eulerAngles.y;

        getScaleScript = GameObject.Find("ScaleBoss").GetComponent<ScaleBossScript>();

        Destroy(gameObject, lifeTime);
	}
	
	// Update is called once per frame
	void Update () {

	transform.position += forward * speed * Time.deltaTime;
    
	}

    //Checks if rocket hits the boss and scale it down.
	void OnTriggerEnter(Collider other){
		if (other.tag == "Boss"){
            getScaleScript.scaleDown = true;
            Destroy(gameObject);
            return;
		}

        if(other.tag == "Props")
        {
            Destroy(gameObject);
        }
    }


}
