using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class DeathField : MonoBehaviour {

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

        private void OnCollisionEnter(Collision other)
        {
            
                Debug.Log(other.gameObject.name);
                if (other.gameObject.tag == "Player")
                {
                    // other.GetComponent<HealthManager>().NumberOfLives = other.GetComponent<HealthManager>().NumberOfLives - 1;
                    other.gameObject.GetComponent<TeleportorController>().manualTeleport();
                }
            
        }



    }

}
