using UnityEngine;
using System.Collections;

public class BazookaScript : MonoBehaviour {

	public bool canShoot;
	public int rocketAmmo;
	public GameObject rocket;

	// Use this for initialization
	void Start () {
		canShoot = true;
		rocketAmmo = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f") && canShoot == true && rocketAmmo > 0) {
			Instantiate (rocket, transform.position, Quaternion.identity);
			canShoot = false;
			rocketAmmo--;
			StartCoroutine(Delay());
		}
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds(0.5f);
		canShoot = true;
	}


}
