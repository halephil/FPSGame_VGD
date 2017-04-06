using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public int bulletDamage = 10;
	public ParticleSystem collide;
	public bool isExplosive = false;
	public float maxExplosionDamage = 100f;
	public float explosionRadius = 5f;
	public float explosionForce = 1000f;
	private Rigidbody rb;
	private Renderer rd;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rd = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision collision){
		if (isExplosive){
			Collider[] colliders = Physics.OverlapSphere (transform.position, explosionRadius);

			foreach(Collider collider in colliders){
				Rigidbody targetBody = collider.GetComponent<Rigidbody>();

				if(targetBody){
					targetBody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
				}

				//Deal explosive damage to enemy
				/*
				HealthScript enemyHealth = collider.GetComponent<HealthScript>();
				if (enemyHealth){
					explosion damage calculations...
				}
				*/
			}
		} else{
				//Deal non-explosive damage to enemy
				/*
				HealthScript enemyHealth = collision.collider.GetComponent<HealthScript>();
				if (enemyHealth){
					enemyHealth.dealDamage(bulletDamage);
				}
				 */
		}

		ContactPoint contact = collision.contacts[0];
		Instantiate(collide, transform.position, Quaternion.FromToRotation(Vector3.up, contact.normal));
		Destroy(gameObject);
	}

	public void setExplosive(float explosiveDamage, float radius, float force){
		isExplosive = true;
		maxExplosionDamage = explosiveDamage;
		explosionRadius = radius;
		explosionForce = force;
	}
}
