using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour {
	private Transform mainCameraTransform;

	// Use this for initialization
	void Start () {
		mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.rotation = mainCameraTransform.rotation;
	}
}
