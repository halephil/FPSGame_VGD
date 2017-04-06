using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : PlayerShoot {

	// Use this for initialization
	new void Start () {
		base.Start();
	}

	new void Update (){
		base.Update();
	}
	
	public override void shoot(){
		base.shoot();
	}
}
