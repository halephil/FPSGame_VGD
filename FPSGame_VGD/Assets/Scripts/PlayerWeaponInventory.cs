using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponInventory : MonoBehaviour {
	public Transform weaponPosition;
	
	private int currentWeapon = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Mouse ScrollWheel") > 0){
			if(currentWeapon >= weaponPosition.childCount - 1){
				currentWeapon = 0;
			}else{
				currentWeapon++;
			}
			switchWeapon();
		}
		if(Input.GetAxis("Mouse ScrollWheel") < 0){
			if(currentWeapon <= 0){
				currentWeapon = weaponPosition.childCount - 1;
			}else{
				currentWeapon--;
			}
			switchWeapon();
		}
	}

	public void addWeapon(GameObject weapon){
		foreach(Transform heldWeapon in weaponPosition){
			heldWeapon.gameObject.SetActive(false);
		}

		GameObject acquiredWeapon = Instantiate(weapon, weaponPosition);
		acquiredWeapon.transform.position = weaponPosition.position;
		acquiredWeapon.transform.rotation = weaponPosition.rotation;
	}

	private void switchWeapon(){
		for (int i = 0; i < weaponPosition.childCount; i++){
			if(i == currentWeapon){
				weaponPosition.GetChild(i).gameObject.SetActive(true);
			} else{
				weaponPosition.GetChild(i).gameObject.SetActive(false);
			}
		}
	}
}
