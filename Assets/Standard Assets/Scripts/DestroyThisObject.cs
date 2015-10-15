using UnityEngine;
using System.Collections;

public class DestroyThisObject : MonoBehaviour
{


	// Use this for initialization
	void Start ()
	{
	
	}


	public void RemoveObject ()
	{
		Destroy (gameObject);
	}

}
