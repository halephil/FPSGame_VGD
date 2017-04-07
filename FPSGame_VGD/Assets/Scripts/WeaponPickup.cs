using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {
	public GameObject weapon;
	public AuraColor auraColor; 
	private Transform pickupHold;
	private ParticleSystem ps;
	private ParticleSystem psBase;

	// Use this for initialization
	void Start () {
		float alpha = 128f;
		Color[] colors = {Color.white, Color.black, new Color(1f, .2f, .2f, alpha),
													new Color(1f, 1f, .2f, alpha),
													new Color(.2f, 1f, .2f, alpha),
													new Color(.2f, .2f, 1f, alpha)};
		
		ps = transform.Find("Aura").GetComponent<ParticleSystem>();
		psBase = ps.gameObject.transform.Find("Aura Base").GetComponent<ParticleSystem>();
		ParticleSystem.MainModule main = ps.main;
		ParticleSystem.MainModule baseMain = psBase.main;
		main.startColor = colors[(int)auraColor];
		psBase.startColor = colors[(int)auraColor];

		pickupHold = transform.Find("Weapon");
		Instantiate(weapon.transform.GetChild(0), pickupHold).transform.position = pickupHold.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Player")){
			Transform weaponHold = other.transform.Find("Player Weapon/Weapon Position");
			if (weaponHold.childCount > 0){
				Destroy(weaponHold.GetChild(0).gameObject);
			}

			Transform equippedWeapon = Instantiate(weapon, weaponHold).transform;
			equippedWeapon.position = weaponHold.position;
			equippedWeapon.rotation = weaponHold.rotation;

			Destroy(gameObject);
		}
	}
}

public enum AuraColor{
	White, Black, Red, Yellow, Green, Blue
}
