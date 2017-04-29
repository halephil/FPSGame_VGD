using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup : MonoBehaviour {
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		sound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")){
			PlayerKeyInventory keyInventory = other.gameObject.GetComponent<PlayerKeyInventory>();
			keyInventory.acquireKey();

			sound.Play();
			gameObject.GetComponent<CapsuleCollider>().enabled = false;
			transform.GetChild(0).gameObject.SetActive(false);
			Destroy(gameObject, 1.0f);
		}
	}
}
