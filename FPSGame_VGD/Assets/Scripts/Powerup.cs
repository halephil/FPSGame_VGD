using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
	public int damageIncrease = 0;
	public float spreadDecrease = 0.0f;
	public float shootSpeedIncrease = 0.0f;

	public Color auraColor;

	private ParticleSystem[] pSystems;

	// Use this for initialization
	void Start () {
		pSystems = GetComponentsInChildren<ParticleSystem>();

		foreach (ParticleSystem aura in pSystems){
			ParticleSystem.MainModule pMain = aura.main;
			pMain.startColor = auraColor;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(!other.gameObject.CompareTag("Player")){
			return;
		}

		PlayerShoot playerWeapon = other.GetComponentInChildren<PlayerShoot>();

		if(playerWeapon){
			playerWeapon.damage += damageIncrease;
			if(playerWeapon.projectileDriftCoefficient > 0){
				playerWeapon.projectileDriftCoefficient -= spreadDecrease;
				if (playerWeapon.projectileDriftCoefficient < 0){
					playerWeapon.projectileDriftCoefficient = 0;
				}
			}
			if(playerWeapon.shootSpeed < 1){
				playerWeapon.shootSpeed += shootSpeedIncrease;
				if (playerWeapon.shootSpeed > 1){
					playerWeapon.shootSpeed = 1;
				}
			}

			Destroy(gameObject);
		}
	}
}
