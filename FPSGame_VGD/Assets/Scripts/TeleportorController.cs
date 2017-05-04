using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

  public class TeleportorController : MonoBehaviour
    {
        public GameObject TeleportTo;
        private GameObject colGO;
        private bool moveUpDown = false;
        private bool moveUp = false;

        private bool Teleported = true;
        private Vector3 colINTPOS, colFLYPOS, TelTo;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (gameObject.tag != "Player")
            {
                transform.Rotate(new Vector3(0, 150, 0) * Time.deltaTime);
                
            }

            movePlayerUpDown();
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "Player" && gameObject.name != "Player")
            {
                Teleported = other.GetComponent<TeleportedTracker>().Teleported;

                if (Teleported == false)
                {
                    Debug.Log(gameObject.name);
                    Debug.Log(Teleported);
                    if (other.name == "Player")
                    {

                        moveUpDown = true;
                        other.GetComponent<FirstPersonController>().GravityMultiplier = 0;
                        other.GetComponent<FirstPersonController>().StickToGroundForce = 0;
                        other.GetComponent<Rigidbody>().useGravity = false;
                        moveUp = true;
                        colGO = other.transform.gameObject;
                        colINTPOS = other.transform.position;
                        TelTo = TeleportTo.transform.position;//TeleportTo.transform.position;

                        TelTo.y = TelTo.y + 4f;
                        Debug.Log(TelTo);
                    }

                }

            }
        }

        private void movePlayerUpDown()
        {

            if (moveUpDown == true)
            {
                Debug.Log(moveUpDown);
                Debug.Log(Teleported);
                if (moveUp == true && Teleported == false)
                {
                    Debug.Log("Up");
                    colGO.transform.position = colGO.transform.position + (new Vector3(0, 3f, 0) * Time.deltaTime);
                    if (colGO.transform.position.y >= (colINTPOS.y + 4))
                    {
                        Debug.Log("Moveing Up");
                        colFLYPOS = colGO.transform.position + new Vector3(2, 0, 2);
                        moveUp = false;
                        
                        colGO.GetComponent<TeleportedTracker>().Teleported = true;
                        Debug.Log(colGO.transform.position);
                        colGO.transform.position = TelTo + new Vector3(1.5f, 0, 1.5f);
                    }

                }

                else
                {

                    colGO.transform.position = colGO.transform.position - (new Vector3(0f, 3f, 0) * Time.deltaTime);
                    if (colGO.transform.position.y <= (TeleportTo.transform.position.y + 1))
                    {
                        Debug.Log("Moveing Down");
                        moveUpDown = false;
                        //colGO.transform.position = colINTPOS;
                        //colGO.GetComponent<WalkingScript>().freezePlayer = false;
                        colGO.GetComponent<TeleportedTracker>().Teleported = false;
                        colGO.GetComponent<FirstPersonController>().GravityMultiplier = 2;
                        colGO.GetComponent<Rigidbody>().useGravity = true;
                        colGO.GetComponent<FirstPersonController>().StickToGroundForce = 10;
                        //PlaceIcon();
                    }
                }

            }

        }

        public void manualTeleport()
        {
            Teleported = false;
            Debug.Log("Manual Teleport");
            Debug.Log(Teleported);
            if (Teleported == false)
            {
                Debug.Log(gameObject.name);
                Debug.Log(Teleported);
                if (gameObject.name == "Player")
                {

                    moveUpDown = true;
                    gameObject.GetComponent<FirstPersonController>().GravityMultiplier = 0;
                    gameObject.GetComponent<FirstPersonController>().StickToGroundForce = 0;
                    gameObject.GetComponent<Rigidbody>().useGravity = false;
                    moveUp = true;
                    colGO = gameObject.transform.gameObject;
                    colINTPOS = gameObject.transform.position;
                    TelTo = TeleportTo.transform.position;//TeleportTo.transform.position;

                    TelTo.y = TelTo.y + 4f;
                    Debug.Log(TelTo);
                }
            }



        }

    }

