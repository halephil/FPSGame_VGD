using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")){
			PlayerKeyInventory keyInventory = other.gameObject.GetComponent<PlayerKeyInventory>();
			keyInventory.acquireKey();
			Destroy(gameObject);
		}
	}
}
