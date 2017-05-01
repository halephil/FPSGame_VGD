using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{

    public class HealthManager : MonoBehaviour {

        public int MaxHealth;
        public int NumberOfLives;
        private int currentHealth;
        private float waitTime;
        public Text HealthText;
        public Text LivesText;
        public Text GameOverText;

        // Use this for initialization
        void Start() {
            waitTime = 0;
            currentHealth = MaxHealth;
            LivesText.text = "Lives: " + NumberOfLives.ToString();
            HealthText.text = "Health: " + currentHealth.ToString();
            GameOverText.text = "";
        }

        // Update is called once per frame
        void Update() {
            checkHealth();
        }

        private void OnTriggerEnter(Collider other)
        {
         
            Debug.Log(other.transform.tag);
            if (other.transform.tag == "Dino")
            {
                if (currentHealth > 0)
                {
                    currentHealth = currentHealth - 5;
                    HealthText.text = "Health: " + currentHealth.ToString();
                }
           }
        }

        private void checkHealth()
        {
            if (currentHealth <= 0)
            {
                if (NumberOfLives > 0)
                {
                    NumberOfLives = NumberOfLives - 1;
                    HealthText.text = "Health: 0";
                    LivesText.text = "Lives: " + NumberOfLives.ToString();
                    currentHealth = 100;
                    gameObject.GetComponent<TeleportorController>().manualTeleport();
                }
                else
                {
                    HealthText.text = "Health: 0";
                    GameOverText.text = "GAME OVER!";
                    waitTime = waitTime + Time.deltaTime;
                    if(waitTime >= 5)
                    {
                        Debug.Log("Load Menu");
                    }
                }
            }
        }
    }

}
