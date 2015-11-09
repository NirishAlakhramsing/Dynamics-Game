using UnityEngine;
using System.Collections;

public class WeaponHolderScript : MonoBehaviour {


    public GameObject bazooka;
    public int ammo;


    // Use this for initialization
    void Start () {
        

        ammo = 0;

	}
	
	// Update is called once per frame
	void Update () {

	}

    //Puts weapon onto players right side
    public void AquireWeapon(int weaponNumber)
    {
        if (weaponNumber == 0 && ammo == 0)
        {
            GameObject aquiredWeapon= Instantiate(bazooka, transform.position, Quaternion.identity) as GameObject;
            
            aquiredWeapon.transform.parent = gameObject.transform;
            aquiredWeapon.transform.localRotation = gameObject.transform.localRotation;

            ammo += 5;
         } else if (ammo > 0)
            {
            ammo += 5;
            }

    }
}
