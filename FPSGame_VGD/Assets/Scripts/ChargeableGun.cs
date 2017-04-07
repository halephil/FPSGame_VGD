using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeableGun : PlayerShoot {
	public float minCharge;
	private float maxCharge;
	public float maxChargeTime = 1;
	private float currentCharge;
	private Canvas chargeCanvas;
	private Slider chargeSlider;

	// Use this for initialization
	new void Start () {
		base.Start();
		currentCharge = minCharge;
		maxCharge = projectileVelocity;
		chargeCanvas = GetComponentInChildren(typeof(Canvas), true) as Canvas;
		chargeSlider = chargeCanvas.GetComponentInChildren<Slider>();
	}

	new void Update (){
		timer += Time.deltaTime;
		shotTime = 1 - shootSpeed;

		if (Input.GetMouseButton((int)fireButton) && timer > shotTime){
			chargeCanvas.gameObject.SetActive(true);

			if (currentCharge >= maxCharge){
				shoot();
			} else {
				//currentCharge += maxChargeTime * Time.deltaTime;
				currentCharge += maxChargeTime * (maxCharge - minCharge) * Time.deltaTime;
				chargeSlider.value = getPercent() / 3;
			}
		} else if (Input.GetMouseButtonUp((int)fireButton) && timer > shotTime){
			shoot();
		}
	}
	
	public override void shoot(){
		chargeCanvas.gameObject.SetActive(false);
		projectileVelocity = currentCharge;
		Debug.Log(projectileVelocity);
		base.shoot();
		currentCharge = minCharge;
	}

	private float getPercent(){
		return 100 * (currentCharge - minCharge) / (maxCharge - minCharge);
	}
}
