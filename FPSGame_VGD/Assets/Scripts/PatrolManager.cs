using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolManager : MonoBehaviour {

    public GameObject ObjectToMove;
    private BoxCollider bxC;
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
    }
	
	// Update is called once per frame
	void Update () {
        checkforSamePos();
       
    }


   

    private void checkforSamePos()
    {
        currentPOS = gameObject.transform.position;
        if((oldPOS.x >= (currentPOS - new Vector3(.1f, .1f, .1f)).x) || (oldPOS.x <= (currentPOS + new Vector3(.1f, .1f, .1f)).x) || (oldPOS.z >= (currentPOS - new Vector3(.1f, .1f, .1f)).z) || (oldPOS.z <= (currentPOS + new Vector3(.1f, .1f, .1f)).z))
        {
            time = Time.deltaTime + time;
            if(time > 3 )
            {
                Debug.Log(time);
                time = 0;
                ObjectToMove.GetComponent<Animation>().Play("Allosaurus_IdleAggressive");
                agent.Stop();
                //while (ObjectToMove.GetComponent<Animation>().IsPlaying("Allosaurus_IdleAggressive") == true)
               // {
                   
                //}
                NewWayPoint(lastCol);
               
            }
        }
        oldPOS = currentPOS;
    }

    public void NewWayPoint(Collider other)
    {
        
        //Debug.Log(other.name);
        if (other.name == ObjectToMove.name)
        {
            while (index == oldIndex)
            {
                index = Random.Range(0, gameObject.transform.childCount);
            }
           // Debug.Log(index);
            oldIndex = index;
            agent.SetDestination(gameObject.transform.GetChild(index).position);
           // Debug.Log("Child Picked: " + gameObject.transform.GetChild(index).name);
            lastCol = other;
            time = 0;
        }
    }
     
}
