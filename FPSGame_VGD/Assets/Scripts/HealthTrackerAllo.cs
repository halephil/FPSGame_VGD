using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HealthTrackerAllo : MonoBehaviour
{
    public float forceAmount;
    public float RunningSpeed;
    public GameObject WinMenu;
    public AudioClip deathSound;
    public AudioClip hurtSound;
    public AudioClip attackSound;
    public GameObject player;
    private NavMeshAgent navMesh;
    private BoxCollider bxC;
    public int health;
    public bool isAttacking;
    private bool IsDead;
    private Animation anim;
    public GameObject blood;
    public float ltime;
    

    // Use this for initialization
    void Start()
    {
       //health = 200;
        anim = gameObject.GetComponent<Animation>();
        navMesh = GetComponent<NavMeshAgent>();
        GetComponent<AudioSource>().playOnAwake = false;
        IsDead = false;
        forceAmount = 0;

    }

    // Update is called once per frame
    void Update()
    {
        ltime = 1;
        GameObject b = GameObject.Find("BloodEffect(Clone)");
        GameObject c = GameObject.Find("BloodEffect2(Clone)");
        Destroy(b, ltime);
        Destroy(c, ltime);
        CheckHealth();
        if(anim.IsPlaying("Allosaurus_Walk") == true || isAttacking == false )
        {

        }

        else if(anim.IsPlaying("Allosaurus_Idle") == true || isAttacking == false)
        {

        }
        else if (anim.IsPlaying("Allosaurus_Hit01") == true || isAttacking == false)
        {
            //Debug.Log("Hit");
            
            navMesh.velocity = Vector3.zero;
            navMesh.ResetPath();
            navMesh.Stop();
        }

        else if (anim.IsPlaying("Allosaurus_Attack02") == true || isAttacking == false)
        {
            Debug.Log("Attack01");
            
            navMesh.velocity = Vector3.zero;
            navMesh.ResetPath();
            navMesh.Stop();
        }

        else if(anim.IsPlaying("Allosaurus_Die") == true || isAttacking == false)
        {
            Debug.Log("Die");
            navMesh.velocity = Vector3.zero;
            navMesh.ResetPath();
            navMesh.Stop();
        }

        else
        {
            navMesh.Resume();
            navMesh.SetDestination(player.transform.position);
        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        if (other.name == "Player")
        {
            anim.Play("Allosaurus_Attack02");
            GetComponent<AudioSource>().clip = attackSound;
            GetComponent<AudioSource>().Play();
           
            //other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forceAmount, ForceMode.VelocityChange);

            //Debug.Log(other.name);
            anim.PlayQueued("Allosaurus_Walk");
        }
    }

    //Called by bullet script when bullet hits collider
    public void takeDamage(int damage){
        health = health - damage;
        Instantiate(blood, transform.position, transform.rotation);
        AfterHit();

        if (health <= 0){
            if (IsDead == false){
                IsDead = true;
                anim.CrossFade("Allosaurus_Die");
                GetComponent<AudioSource>().clip = deathSound;
                GetComponent<AudioSource>().Play();
                navMesh.Stop();
                navMesh.velocity = Vector3.zero;
            }
        }
    }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     //Debug.Log(collision.gameObject.name);
    //     if (collision.gameObject.name == "Bullet(Clone)")
    //     {
    //         health = health - 5;
    //         Instantiate(blood, transform.position, transform.rotation);
    //         AfterHit();
    //     }

    //     else if (collision.gameObject.name == "Rocket(Clone)")
    //     {
    //         health = health - 20;
    //         Instantiate(blood, transform.position, transform.rotation);
    //         AfterHit();
      
    //     }

    //     else if (collision.gameObject.name == "Grenade(Clone)")
    //     {
    //         health = health - 10;
    //         Instantiate(blood, transform.position, transform.rotation);
    //         AfterHit();
            
    //     }
    //     else
    //     {

    //     }

    //     if (health <= 0)
    //     {
    //         if (IsDead == false)
    //         {
    //             IsDead = true;
    //             anim.CrossFade("Allosaurus_Die");
    //             GetComponent<AudioSource>().clip = deathSound;
    //             GetComponent<AudioSource>().Play();
    //             navMesh.Stop();
    //             navMesh.velocity = Vector3.zero;
    //         }
    //     }
    // }

    private void AfterHit()
    {
        
        
        gameObject.transform.parent.GetComponent<AlloValuePasser>().SetAttack(true);
      
       anim.Play("Allosaurus_Hit01");
       navMesh.velocity = Vector3.zero;
        navMesh.SetDestination(player.transform.position);
        navMesh.Stop();
       
        navMesh.speed = RunningSpeed;
        gameObject.transform.parent.GetComponent<AlloValuePasser>().SetAttack(true);


        anim.PlayQueued("Allosaurus_Run");
        //Debug.Log(health);
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
                if(gameObject.transform.parent.gameObject.tag == "Boss")
                {
                    Time.timeScale = 0;
                    WinMenu.SetActive(true);
                }
                Destroy(gameObject.transform.parent.gameObject);
            }


        }
    }


}

