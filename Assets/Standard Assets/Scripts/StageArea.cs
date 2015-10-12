using UnityEngine;
using System.Collections;

public class StageArea : MonoBehaviour {

	public GameObject mine;
	public Vector3  veinProximityMin, veinProximityMax, randSpawnPosition;
	private float rndXposition, rndZposition;
	public bool startSpawning;
	public int mineCount, maxMines;

	// Use this for initialization
	void Start () {
		startSpawning = false;
		randSpawnPosition = gameObject.transform.position;
		mineCount = 0;
		maxMines = 5;
	}
	
	// Update is called once per frame
	void Update () {

		if (startSpawning && (mineCount != maxMines)) {
			SpawnMine ();
		} else {
			startSpawning = false;
		}
	}

	void SpawnMine(){
		Instantiate (mine, GetPosition(randSpawnPosition), Quaternion.identity);
		mineCount++;
	}

	Vector3 GetPosition(Vector3 OldPosition){
		
		rndXposition = Random.Range ( veinProximityMin.x, veinProximityMax.x);
		rndZposition = Random.Range ( veinProximityMin.z, veinProximityMax.z);
		
		OldPosition = new Vector3 (rndXposition, 0.5f, rndZposition);
		
		return OldPosition;
	}
}
