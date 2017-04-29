using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestal : MonoBehaviour {
	public GameObject key;
	public Transform keyHolder;
	private bool keyPlaced = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.CompareTag("Player") && !keyPlaced && (other.GetComponent<PlayerKeyInventory>().getNumOfKeys() > 0)){
			other.GetComponent<PlayerKeyInventory>().removeKey();

			GameObject placedKey = Instantiate(key, keyHolder).GetComponent<CapsuleCollider>().gameObject;
			placedKey.GetComponent<CapsuleCollider>().enabled = false;
			placedKey.transform.position = keyHolder.position;
			keyPlaced = true;
			Debug.Log("Pedestal: Key Placed");
		}
	}

	public bool hasKey(){
		return keyPlaced;
	}
}
