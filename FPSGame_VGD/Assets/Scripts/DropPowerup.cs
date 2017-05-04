using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPowerup : MonoBehaviour {
	public GameObject[] powerups;
	public int powerupDropChance = 50;

	public GameObject key;
	public int keyDropChance = 50;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy(){
		float dropNum = Random.Range(0f, 100f);
		if(dropNum <= powerupDropChance){
			Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
			int selectNum = Random.Range(0, powerups.Length);
			Instantiate(powerups[selectNum], pos, powerups[selectNum].transform.rotation);
		}

		dropNum = Random.Range(0f, 100f);
		if(dropNum <= keyDropChance){
			Vector3 pos = new Vector3(transform.position.x, transform.position.y + 1.2f, transform.position.z);
			Instantiate(key, pos, transform.rotation);
		}
	}
}
