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
		ContactPoint contact = collision.contacts[0];
		Debug.Log(contact.otherCollider.gameObject.name);

		if (contact.otherCollider.gameObject.CompareTag("Player")){
			return;
		}

		if (isExplosive){
			Collider[] colliders = Physics.OverlapSphere (transform.position, explosionRadius);

			foreach(Collider collider in colliders){
				Rigidbody targetBody = collider.GetComponent<Rigidbody>();

				if(targetBody){
					targetBody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
				}
			}
		}

		HealthTrackerAllo enemyHealth = collision.collider.GetComponentInParent<HealthTrackerAllo>();
		if (enemyHealth){
			enemyHealth.takeDamage(bulletDamage);
			// Debug.Log(bulletDamage);
		}

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
