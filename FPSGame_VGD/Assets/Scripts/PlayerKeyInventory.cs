using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyInventory : MonoBehaviour {
	private int numOfKeys = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getNumOfKeys(){
		return numOfKeys;
	}

	public void acquireKey(){
		numOfKeys += 1;
		Debug.Log("Key acquired - keys: " + numOfKeys);
	}

	public void removeKey(){
		numOfKeys -= 1;
		Debug.Log("Key removed - keys: " + numOfKeys);
	}
}
