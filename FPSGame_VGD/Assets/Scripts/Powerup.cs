using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
	public int damageIncrease = 0;
	public float spreadIncrease = 0.0f;
	public float shootSpeedIncrease = 0.0f;

	public Color auraColor;

	private ParticleSystem[] pSystems;
	private AudioSource sound;

	// Use this for initialization
	void Start () {
		pSystems = GetComponentsInChildren<ParticleSystem>();
		sound = GetComponent<AudioSource>();

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
			playerWeapon.updateDamage(damageIncrease);
			playerWeapon.updateShootSpeed(shootSpeedIncrease);
			if(playerWeapon.GetType() == typeof(Shotgun)){
				spreadIncrease *= 2.5f;
			}
			playerWeapon.updateDrift(spreadIncrease);

			sound.Play();
			gameObject.GetComponent<CapsuleCollider>().enabled = false;
			foreach(Transform item in transform){
				item.gameObject.SetActive(false);
			}
			Destroy(gameObject, 1.0f);
		}
	}
}
