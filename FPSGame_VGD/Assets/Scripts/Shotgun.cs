using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : PlayerShoot {
	public int numberOfShots = 5;

	// Use this for initialization
	new void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	new void Update () {
		base.Update();
	}

	public override void shoot(){
		timer = 0.0f;
		
		getAim();
		animateAndSound();
		for (int i = 0; i < numberOfShots; i++){
			createProjectile(damage);
		}

		if (ps){
			ps.Play();
		}
	}
}
