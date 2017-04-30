using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlloValuePasser : MonoBehaviour {

	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetAttack(bool attacking)
    {
        gameObject.transform.FindChild("Patrol Manager").GetComponent<PatrolManager>().beingAttacked = attacking;
        gameObject.transform.FindChild("Allosaurus w_BodyC").GetComponent<HealthTrackerAllo>().isAttacking = attacking;
    }
}
