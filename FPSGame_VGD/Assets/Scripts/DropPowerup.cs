using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropPowerup : MonoBehaviour {
	public GameObject powerupPrefab;
	public int dropChance = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy(){
		int num = Mathf.RoundToInt(Random.Range(0f, 100f));
		
		if(num <= dropChance){
			Vector3 pos = new Vector3(transform.position.x, 1, transform.position.z);
			Transform powerup = Instantiate(powerupPrefab, pos, powerupPrefab.transform.rotation).transform;
		}
	}
}
