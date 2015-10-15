using UnityEngine;
using System.Collections;

public class StageArea : MonoBehaviour
{

	public GameObject mine;
	public Vector3  veinProximityMin, veinProximityMax, randSpawnPosition, veinProximity2Min, veinProximity2Max;
	private float rndXposition, rndZposition;
	public bool startSpawning;
	public int mineCount, maxMines;

	// Use this for initialization
	void Start ()
	{
		startSpawning = false;
		randSpawnPosition = gameObject.transform.position;
		mineCount = 0;
		maxMines = 1;
		Debug.Log (randSpawnPosition);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (startSpawning) {
			for (int i = 0; i < maxMines; i++) {
				SpawnMine ();
				mineCount++;
			}
			maxMines++;
			StopSpawning ();
		} else {
			startSpawning = false;
		}
	}

	void SpawnMine ()
	{
		Instantiate (mine, GetPosition (randSpawnPosition), Quaternion.identity);
		//Instantiate (mine, GetSecondPosition (randSpawnPosition), Quaternion.identity);
		mineCount++;
	}

	Vector3 GetPosition (Vector3 OldPosition)
	{
		rndXposition = Random.Range (veinProximityMin.x, veinProximityMax.x);
		rndZposition = Random.Range (veinProximityMin.z, veinProximityMax.z);
		OldPosition = new Vector3 (rndXposition, 0.5f, rndZposition);
		return OldPosition;
	}

	Vector3 GetSecondPosition (Vector3 OldPosition)
	{
		rndXposition = Random.Range (veinProximity2Min.x, veinProximity2Max.x);
		rndZposition = Random.Range (veinProximity2Min.z, veinProximity2Max.z);
		OldPosition = new Vector3 (rndXposition, 0.5f, rndZposition);
		return OldPosition;
	}

	void StopSpawning ()
	{
		if (mineCount >= maxMines) {
			startSpawning = false;
			mineCount = 0;
		}
	}
}
