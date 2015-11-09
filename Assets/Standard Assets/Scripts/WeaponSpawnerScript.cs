using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSpawnerScript : MonoBehaviour {

    public float speed;
    private int weaponType;
    public bool showRocket;
    public GameObject weaponOne;
    private WeaponHolderScript getWeaponHolderScript;

	// Use this for initialization
	void Start () {
        showRocket = false;
        getWeaponHolderScript = GameObject.Find("WeaponHolder").GetComponent<WeaponHolderScript>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
        SpawnWeapon();
    }

    //Spawn weaponType on location
    void SpawnWeapon()
    {
        if (showRocket)
        {
            GameObject bazooka = Instantiate(weaponOne, transform.position, Quaternion.identity) as GameObject;
            bazooka.transform.parent = gameObject.transform;
            bazooka.transform.localRotation = (gameObject.transform.localRotation);
            Component.Destroy(bazooka.GetComponent<BazookaScript>());
            weaponType = 0;
            showRocket = false;
        }
    }


    //Remove it from spawn location and pass weapontype 
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PassWeaponType(weaponType);
            RemoveChild();
            Destroy(gameObject);
        }
    }

    //Pass weapontype to player weaponHolderScript
    void PassWeaponType(int weaponNumber)
    {

        if (weaponNumber!= null)
        {
            getWeaponHolderScript.AquireWeapon(weaponNumber);
        }
        else
        {
            Debug.Log("No weapontype passed to player");
        }

    }

    //Remove weapon visual object from the location spawner.
    void RemoveChild()
    {
        foreach (Transform bazooka in gameObject.transform)
        {
            Destroy(bazooka.gameObject);
        }
    }
}
