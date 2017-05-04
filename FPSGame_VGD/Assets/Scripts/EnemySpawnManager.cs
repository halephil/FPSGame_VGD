using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour {
	public Transform spawnPoint;
	public GameObject enemy;
	public float spawnTime;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("spawn", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void spawn(){
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
	}
}
