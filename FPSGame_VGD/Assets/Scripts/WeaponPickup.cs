using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour {
	public GameObject weapon;
	public Color auraColor; 
	private Transform pickupHold;
	private ParticleSystem[] pSystems;
	private ParticleSystem ps;
	private ParticleSystem psBase;

	// Use this for initialization
	void Start () {	
		pSystems = GetComponentsInChildren<ParticleSystem>();

		foreach (ParticleSystem aura in pSystems){
			ParticleSystem.MainModule pMain = aura.main;
			pMain.startColor = auraColor;
		}

		pickupHold = transform.Find("Weapon");

		Transform weaponModel = Instantiate(weapon.transform.GetChild(0), pickupHold);
		weaponModel.position = pickupHold.position;
		weaponModel.localScale = new Vector3(0.4f, 0.4f, 0.4f);
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
