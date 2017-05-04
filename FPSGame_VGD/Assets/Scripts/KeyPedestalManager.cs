using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPedestalManager : MonoBehaviour {
	public Pedestal[] pedestalsInScene;
	private bool mAllKeysPlaced = false;
	private bool eventTriggered = false;

	// Use this for initialization
	void Start () {
        GameObject.Find("BossTeleportorA").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		if(!mAllKeysPlaced)
        {
			bool hasKey = true;
			foreach(Pedestal pedestal in pedestalsInScene)
            {
				hasKey = hasKey && pedestal.hasKey();
		    }
			mAllKeysPlaced = hasKey;
			//Debug.Log("All Keys Placed: " + mAllKeysPlaced);
		}
        else
        {

            //Do some action here when all keys are placed on all pedestals
            
           

            if(eventTriggered == false)
            {
               onAllKeysPlaced();
            }
        }
	}

	private void onAllKeysPlaced(){
		eventTriggered = true;

        GameObject.Find("Teleportors").GetComponent<ActivateTeleportors>().ActivateBossTele();
		GameObject.Find("Enemy Spawn Manager").SetActive(false);
		GameObject.Find("Allo_wNavBoss").GetComponentInChildren(typeof(HealthTrackerAllo), true).gameObject.SetActive(true);
		//Do some action here when all keys are placed on all pedestals

		Debug.Log("All Keys Placed");
	}

	public bool allKeysPlaced(){
		return mAllKeysPlaced;
	}
}
