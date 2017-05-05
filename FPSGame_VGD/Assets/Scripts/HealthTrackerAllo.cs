using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class HealthTrackerAllo : MonoBehaviour
{
    public float walkingSpeed;
    public float RunningSpeed;
    public GameObject WinMenu;

    public AudioClip deathSound;
    public AudioClip hurtSound;
    public AudioClip attackSound;
    
    private NavMeshAgent navMesh;
    public int health;
    public bool isAttacking;
    private bool IsDead;
    private Animation anim;
    public GameObject blood;
    public float ltime;

    private Transform player;
    private HealthManager playerHealth;
    
    public int damage;
    private bool isDead = false;
    private ParticleSystem bloodSplat;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animation>();
        navMesh = GetComponent<NavMeshAgent>();
        bloodSplat = GetComponentInChildren<ParticleSystem>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = player.GetComponent<HealthManager>();

        IsDead = false;
        navMesh.SetDestination(player.position);
        navMesh.speed = walkingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isPlayingAnimation()){
            navMesh.SetDestination(player.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isDead){
            return;
        }
        
        if (other.name == "Player")
        {
            navMesh.Stop();
            navMesh.ResetPath();
            navMesh.speed = RunningSpeed;

            anim.Play("Allosaurus_Attack02");
            playerHealth.takeDamage(damage);

            anim.PlayQueued("Allosaurus_Run");
            GetComponent<AudioSource>().clip = attackSound;
            GetComponent<AudioSource>().Play();
           
            //other.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * forceAmount, ForceMode.VelocityChange);

            //Debug.Log(other.name);
            
        }
    }

    //Called by bullet script when bullet hits collider
    public void takeDamage(int damage){
        if(health <= 0){
            return;
        }

        health = health - damage;
        navMesh.Stop();
        navMesh.ResetPath();
        navMesh.speed = RunningSpeed;

        // Instantiate(blood, transform.position, transform.rotation);
        int num = Random.Range(0, 100);
        if (num < 50){
            anim.Play("Allosaurus_Hit01");
        } else{
            anim.Play("Allosaurus_Hit02");
        }
        if(bloodSplat){
            bloodSplat.Play();
        }
        anim.PlayQueued("Allosaurus_Run");
        GetComponent<AudioSource>().clip = hurtSound;
        GetComponent<AudioSource>().Play();

        if (health <= 0){
            die();
        }
    }

    private void die(){
        isDead = true;
        navMesh.Stop();
        anim.CrossFade("Allosaurus_Die");
        GetComponent<AudioSource>().clip = deathSound;
        GetComponent<AudioSource>().Play();

        if(WinMenu){
            WinMenu.SetActive(true);
        }
        Destroy(transform.parent.gameObject, anim.GetClip("Allosaurus_Die").length);
    }

    private bool isPlayingAnimation(){
        return anim.IsPlaying("Allosaurus_Hit01") || anim.IsPlaying("Allosaurus_Hit02") || anim.IsPlaying("Allosaurus_Attack02");
    }

    void CheckHealth(){
        if (health <= 0){
            if (anim.IsPlaying("Allosaurus_Die") == false){
                if(gameObject.transform.parent.gameObject.tag == "Boss"){
                    Time.timeScale = 0;
                    WinMenu.SetActive(true);
                }
                Destroy(gameObject.transform.parent.gameObject);
            }
        }
    }
}

