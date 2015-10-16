using UnityEngine;
using System.Collections;

public class RocketScript : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.forward * speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider other){
		//Debug.Log (other);
		if (other.tag == "Boss"){
			Destroy(gameObject);
			return;
		}
		//
	}
}
