using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTracker : MonoBehaviour {
    public float forceAmount;
    public AudioClip deathSound;
    public AudioClip hurtSound;
    public AudioClip attackSound;
   
    private int health;
    private Animation anim;
    
	// Use this for initialization
	void Start () {
        health = 1000;
        anim = gameObject.GetComponent<Animation>();
        GetComponent<AudioSource>().playOnAwake = false;

        forceAmount = 0;

    }
	
	// Update is called once per frame
	void Update () {
        CheckHealth();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "FPSController")
        {
            anim.CrossFade("Attack");
            anim.PlayQueued("Walk");
            GetComponent<AudioSource>().clip = attackSound;
            GetComponent<AudioSource>().Play();
        
            other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward *forceAmount, ForceMode.VelocityChange);
            
            Debug.Log(other.name);
            

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            health = health - 5;
            AfterHit();
        }

        else if (collision.gameObject.name == "Rocket(Clone)")
        {
            health = health - 20;
            AfterHit();
        }

        else if (collision.gameObject.name == "Grenade(Clone)")
        {
            health = health - 10;
            AfterHit();
        }
        else
        {
            
        }

        if(health <= 0)
        {
            anim.CrossFade("Stand Die");
            GetComponent<AudioSource>().clip = deathSound;
            GetComponent<AudioSource>().Play();
        }
        
       

    }
    private void AfterHit()
    {
       
        anim.Play("Hurt");
        anim.PlayQueued("Walk");
        Debug.Log(health);
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().clip = hurtSound;
            GetComponent<AudioSource>().Play();
        }
    }

    void CheckHealth()
    {
        if(health <= 0)
        {
            if (anim.IsPlaying("Stand Die") == false)
            {
                Destroy(gameObject);
            }
            
          
        }
    }


}

