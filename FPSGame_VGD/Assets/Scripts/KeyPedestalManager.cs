using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPedestalManager : MonoBehaviour {
	public Pedestal[] pedestalsInScene;
	private bool mAllKeysPlaced = false;
	private bool eventTriggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!mAllKeysPlaced){
			bool hasKey = true;
			foreach(Pedestal pedestal in pedestalsInScene){
				hasKey = hasKey && pedestal.hasKey();
			}
			mAllKeysPlaced = hasKey;
			// Debug.Log("All Keys Placed: " + allKeysPlaced);
		} else{
			if(eventTriggered == false){
				onAllKeysPlaced();
			}
		}
	}

	private void onAllKeysPlaced(){
		eventTriggered = true;
		//Do some action here when all keys are placed on all pedestals

		Debug.Log("All Keys Placed");
	}

	public bool allKeysPlaced(){
		return mAllKeysPlaced;
	}
}
