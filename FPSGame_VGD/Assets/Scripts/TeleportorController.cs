using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    public class TeleportorController : MonoBehaviour
    {
        private GameObject colGO;
        private bool moveUpDown = false;
        private bool moveUp = false;
       
        private bool Teleported = true;
        private Vector3 colINTPOS, colFLYPOS , TelTo;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(new Vector3(0, 230, 0) * Time.deltaTime);
            movePlayerUpDown();
        }


        private void OnTriggerEnter(Collider other)
        {
            Teleported = other.GetComponent<FirstPersonController>().Teleported;

            if (Teleported == false)
            {
                
                Debug.Log(Teleported);
                if (other.name == "FPSController")
                {
                    moveUpDown = true;
                    other.GetComponent<FirstPersonController>().GravityMultiplier = 0;
                    other.GetComponent<Rigidbody>().useGravity = false;
                    moveUp = true;
                    colGO = other.transform.gameObject;
                    colINTPOS = other.transform.position;
                    if (gameObject.name == "TeleportorA")
                    {
                        TelTo = GameObject.Find("TeleportorB").transform.position;
                    }
                    if (gameObject.name == "TeleportorB")
                    {
                        TelTo = GameObject.Find("TeleportorA").transform.position;
                    }

                    TelTo.y = TelTo.y + 4f;
                }

            }
        }

        private void movePlayerUpDown()
        {
            
            if (moveUpDown == true)
            {
                if(moveUp == true && Teleported == false)
                {
                    Debug.Log("Moveing Up");
                   colGO.transform.position = colGO.transform.position + (new Vector3(0, 3f, 0) * Time.deltaTime);
                    if (colGO.transform.position.y >= (colINTPOS.y + 4))
                    {
                        colFLYPOS = colGO.transform.position + new Vector3(1,0,1);
                        moveUp = false;
                       
                        colGO.GetComponent<FirstPersonController>().Teleported = true;
                        colGO.transform.position = TelTo + new Vector3(1.5f, 0, 1.5f);
                    }

                }

                else
                {
                    Debug.Log("Moveing Down");
                    colGO.transform.position = colGO.transform.position - (new Vector3(0f, 3f, 0) * Time.deltaTime);
                    if (colGO.transform.position.y <= (colINTPOS.y))
                    {
                       
                        moveUpDown = false;
                        colGO.transform.position = colINTPOS;
                        //colGO.GetComponent<WalkingScript>().freezePlayer = false;
                        colGO.GetComponent<FirstPersonController>().Teleported = false;
                        colGO.GetComponent<FirstPersonController>().GravityMultiplier = 2;
                        colGO.GetComponent<Rigidbody>().useGravity = true;
                        //PlaceIcon();
                    }
                }
                
            }

        }

      

    }

}
