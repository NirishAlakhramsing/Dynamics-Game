using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSpawnerScript : MonoBehaviour {

    public float speed;
    public bool showRocket;
    public GameObject weaponOne;

	// Use this for initialization
	void Start () {

        showRocket = false;
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        SpawnWeapon();
    }

    void SpawnWeapon()
    {
        if (showRocket)
        {
            GameObject rocket = Instantiate(weaponOne, transform.position, Quaternion.identity) as GameObject;
            rocket.transform.parent = gameObject.transform;
            Component.Destroy(rocket.GetComponent<BazookaScript>());
            //foreach (Component part in rocket.transform) { 
            Component.Destroy(rocket.GetComponentInChildren<CapsuleCollider>());
            //}
            showRocket = false;
        }
    }

    void RemoveChild()
    {
        foreach(Transform rocket in gameObject.transform)
        {
            Destroy(rocket.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            RemoveChild();
        }
    }
}
