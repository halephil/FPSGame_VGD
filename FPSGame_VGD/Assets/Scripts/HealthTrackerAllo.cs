using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HealthTrackerAllo : MonoBehaviour
{
    public float forceAmount;
    public AudioClip deathSound;
    public AudioClip hurtSound;
    public AudioClip attackSound;
    private NavMeshAgent navMesh;
    private BoxCollider bxC;
    private int health;
    private Animation anim;

    // Use this for initialization
    void Start()
    {
        health = 1000;
        anim = gameObject.GetComponent<Animation>();
        navMesh = GetComponent<NavMeshAgent>();
        GetComponent<AudioSource>().playOnAwake = false;
        
        forceAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
      
        CheckHealth();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            anim.Play("Allosaurus_Attack02");
            GetComponent<AudioSource>().clip = attackSound;
            GetComponent<AudioSource>().Play();
            navMesh.SetDestination(GameObject.Find("Player").transform.position);
            //other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forceAmount, ForceMode.VelocityChange);

            Debug.Log(other.name);
            anim.PlayQueued("Allosaurus_Walk");
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

        if (health <= 0)
        {
            anim.CrossFade("Allosaurus_Die");
            GetComponent<AudioSource>().clip = deathSound;
            GetComponent<AudioSource>().Play();
        }



    }
    private void AfterHit()
    {

        anim.Play("Allosaurus_Hit01");
        anim.PlayQueued("Allosaurus_Walk");
        Debug.Log(health);
        if (GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().clip = hurtSound;
            GetComponent<AudioSource>().Play();
        }
    }

    void CheckHealth()
    {
        if (health <= 0)
        {
            if (anim.IsPlaying("Allosaurus_Die") == false)
            {
                Destroy(gameObject);
            }


        }
    }


}

