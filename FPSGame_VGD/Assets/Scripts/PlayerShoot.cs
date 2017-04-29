using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public FireButton fireButton;
	
	public Rigidbody projectile;
	public Transform firePoint;
	private Transform mainCameraTransform;
	public float projectileVelocity = 30.0f;
	public float projectileDriftCoefficient = 1.0f;
	public float minDrift = 0f;
	public float projectileLifetime = 1.0f;

	public int damage = 10;
	public int maxDamage = 50;
	public float shootSpeed = 0.6f;
	public float maxShootSpeed = 1.0f;
	protected float shotTime;
	protected float timer;

	protected Animator animator;
	protected AudioSource clip;
	public ParticleSystem blastParticles;
	protected ParticleSystem ps;

	// Use this for initialization
	public virtual void Start () {
		mainCameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
		animator = GetComponent<Animator>();
		clip = GetComponent<AudioSource>();

		if (blastParticles){
			ps = Instantiate(blastParticles, firePoint.position, firePoint.rotation);
			ps.transform.parent = firePoint.parent;
		}
	}

	public virtual void Update(){
		timer += Time.deltaTime;

		shotTime = 1 - shootSpeed;

		if(Input.GetMouseButton((int)fireButton) && timer > shotTime){
			shoot();
		}
	}

	protected RaycastHit getAim(){
		Ray aimRay = new Ray(mainCameraTransform.position, mainCameraTransform.forward);
		RaycastHit aimHit;

		if (Physics.Raycast(aimRay, out aimHit, 100.0f)){
			firePoint.transform.LookAt(aimHit.point);
		} else{
			firePoint.transform.LookAt(aimRay.origin + aimRay.direction * 100f);
		}

		return aimHit;
	}

	protected void animateAndSound(){
		if(animator){
			animator.SetTrigger("isFiring");
		}

		if (ps){
			ps.Play();
		}

		if(clip){
			clip.Play();
		}
	}

	public void createProjectile(int damage){
		Quaternion pRotation = Quaternion.Euler(firePoint.transform.eulerAngles.x - projectile.transform.eulerAngles.x,
												firePoint.transform.eulerAngles.y,
												firePoint.transform.eulerAngles.z);
		Rigidbody firedProjectile = Instantiate(projectile, firePoint.position, pRotation) as Rigidbody;
		firedProjectile.GetComponent<Bullet>().bulletDamage = damage;
		Vector3 projectileDrift = new Vector3(Random.value-0.5f, Random.value-0.5f, Random.value-0.5f) * projectileDriftCoefficient;

		firedProjectile.velocity = projectileVelocity * firePoint.forward + projectileDrift;

		Destroy(firedProjectile.gameObject, projectileLifetime);
	}

	public virtual void shoot(){
		timer = 0.0f;
		
		getAim();
		animateAndSound();
		createProjectile(damage);
	}

	public void updateDamage(int updateValue){
		damage += updateValue;

		if(damage > maxDamage){
			damage = maxDamage;
		}

		if(damage < 5){
			damage = 5;
		}
	}

	public void updateShootSpeed(float updateValue){
		shootSpeed += updateValue;

		if(shootSpeed < 0.1f){
			shootSpeed = 0.1f;
		}
		if(shootSpeed > maxShootSpeed){
			shootSpeed = maxShootSpeed;
		}
	}

	public void updateDrift(float updateValue){
		projectileDriftCoefficient += updateValue;

		if(projectileDriftCoefficient < minDrift){
			projectileDriftCoefficient = minDrift;
		}
		if(projectileDriftCoefficient > 20f){
			projectileDriftCoefficient = 20f;
		}
	}
}

public enum FireButton{
	MainFire, AltFire
}
