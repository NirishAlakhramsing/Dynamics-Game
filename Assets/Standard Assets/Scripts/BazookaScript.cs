using UnityEngine;
using System.Collections;

public class BazookaScript : MonoBehaviour {

	public bool canShoot;
	public GameObject rocket;
    private Transform r_Transform;

    WeaponHolderScript getWeaponHolderScript;
	// Use this for initialization
	void Start () {
        getWeaponHolderScript = GameObject.Find("WeaponHolder").GetComponent<WeaponHolderScript>();

        this.r_Transform = this.gameObject.transform;
		canShoot = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("f") && canShoot == true && getWeaponHolderScript.ammo > 0 ) {
			Instantiate (rocket, r_Transform.position, r_Transform.rotation);
			canShoot = false;
            getWeaponHolderScript.ammo--;
			StartCoroutine(Delay());
		}
	}

	IEnumerator Delay(){
		yield return new WaitForSeconds(0.5f);
		canShoot = true;
	}


}
