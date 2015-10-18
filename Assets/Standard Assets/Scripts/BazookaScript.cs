using UnityEngine;
using System.Collections;

public class BazookaScript : MonoBehaviour {

	public bool canShoot;
	public int rocketAmmo;
	public GameObject rocket;
    private Transform r_Transform;

	// Use this for initialization
	void Start () {

        this.r_Transform = this.gameObject.transform;
		canShoot = true;
		rocketAmmo = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f") && canShoot == true && rocketAmmo > 0) {
			Instantiate (rocket, r_Transform.position, r_Transform.rotation);
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
