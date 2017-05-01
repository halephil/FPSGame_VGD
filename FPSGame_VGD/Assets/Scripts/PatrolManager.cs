using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolManager : MonoBehaviour {

    public GameObject ObjectToMove;
    public bool beingAttacked;
    public float ChangePathTime;
    private BoxCollider bxC;
    private bool newWayPointNeeded;
    int index;
    int oldIndex;
    Vector3 oldPOS, currentPOS;
    float time;
    private Collider lastCol;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
        index = 0;
        oldIndex = 0;
        agent = ObjectToMove.GetComponent<NavMeshAgent>();
        agent.SetDestination(gameObject.transform.GetChild(index).position);
        bxC = ObjectToMove.GetComponent<BoxCollider>();
        newWayPointNeeded = false;
        beingAttacked = false;
    }
	
	// Update is called once per frame
	void Update () {
        checkforSamePos();
       
    }


   

    private void checkforSamePos()
    {
        currentPOS = gameObject.transform.position;
        //Debug.Log(ObjectToMove.GetComponent<Animation>().IsPlaying("Allosaurus_Idle"));
        //Debug.Log(time);
        if(ObjectToMove.GetComponent<Animation>().IsPlaying("Allosaurus_Idle") == false)
        {
            if(newWayPointNeeded == true)
            {
                NewWayPoint(lastCol);
                newWayPointNeeded = false;
            }

            if ((oldPOS.x >= (currentPOS - new Vector3(.1f, .1f, .1f)).x) || (oldPOS.x <= (currentPOS + new Vector3(.1f, .1f, .1f)).x) || (oldPOS.z >= (currentPOS - new Vector3(.1f, .1f, .1f)).z) || (oldPOS.z <= (currentPOS + new Vector3(.1f, .1f, .1f)).z))
            {
                time = Time.deltaTime + time;
                if (time > ChangePathTime)
                {
                    //Debug.Log(time);
                    time = 0;
                    ObjectToMove.GetComponent<Animation>()["Allosaurus_Idle"].wrapMode = WrapMode.Once;
                    ObjectToMove.GetComponent<Animation>().CrossFade("Allosaurus_Idle");
                    ObjectToMove.GetComponent<Animation>().PlayQueued("Allosaurus_Walk");
                    newWayPointNeeded = true;
                    gameObject.transform.parent.GetComponent<AlloValuePasser>().SetAttack(false);
                    agent.speed = 1;
                    //agent.SetDestination(lastCol.gameObject.transform.position);
                }
            }
            

        }

        else
        {
            agent.velocity = Vector3.zero;
            agent.ResetPath();
        }

        oldPOS = currentPOS;
    }

    public void NewWayPoint(Collider other)
    {

        //Debug.Log(other.name);
        if (beingAttacked == false)
        {

            Debug.Log(other.name);
            Debug.Log(ObjectToMove.name);
            if (other.name == ObjectToMove.name)
            {
                lastCol = other;
                while (index == oldIndex)
                {
                    index = Random.Range(0, gameObject.transform.childCount);
                }
                //Debug.Log(index);
                oldIndex = index;
                agent.SetDestination(gameObject.transform.GetChild(index).position);
                agent.Resume();
                //Debug.Log("Child Picked: " + gameObject.transform.GetChild(index).name);

                time = 0;
            }

            

        }
        
    }

    

}
