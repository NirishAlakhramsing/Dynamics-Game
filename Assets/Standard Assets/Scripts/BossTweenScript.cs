using UnityEngine;
using System.Collections;

public class BossTweenScript : MonoBehaviour {

	Hashtable ht = new Hashtable ();

	void Awake ()
	{
		ht.Add ("y", 10f);
		ht.Add ("time", 3f);
		ht.Add ("delay", 2f);
		ht.Add ("looptype", iTween.LoopType.none);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void JumpTween(){

		iTween.MoveBy (gameObject, ht);

	}
}
