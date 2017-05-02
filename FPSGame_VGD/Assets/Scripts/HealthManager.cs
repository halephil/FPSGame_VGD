﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets.Characters.FirstPerson
{

    public class HealthManager : MonoBehaviour {
        public GameObject GameOverMenu;
        public int MaxHealth;
        public int NumberOfLives;
        private int currentHealth;
        public int AllosaurusDamage;
        public int BossDamage;
       
        public Text HealthText;
        public Text LivesText;
        

        // Use this for initialization
        void Start() {
           
            currentHealth = MaxHealth;
            LivesText.text = "Lives: " + NumberOfLives.ToString();
            HealthText.text = "Health: " + currentHealth.ToString();
           
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
                if (other.gameObject.GetComponent<Animation>().IsPlaying("Allosaurus_Attack02") == true)
                {
                    if (currentHealth > 0)
                    {
                        currentHealth = currentHealth - AllosaurusDamage;
                        HealthText.text = "Health: " + currentHealth.ToString();
                    }
                }
            }

            if (other.transform.tag == "Boss")
            {
                if (other.gameObject.GetComponent<Animation>().IsPlaying("Allosaurus_Attack02") == true)
                {
                    if (currentHealth > 0)
                    {
                        currentHealth = currentHealth - BossDamage;
                        HealthText.text = "Health: " + currentHealth.ToString();
                    }
                }
            }
            else if (other.transform.tag == "DeathField")
            {
                gameObject.GetComponent<TeleportorController>().manualTeleport();
                RemoveLife();
                
            }

            else
            {

            }
        }

        private void checkHealth()
        {
            if (currentHealth <= 0)
            {
                if (NumberOfLives > 0)
                {
                    RemoveLife();
                    HealthText.text = "Health: 100";
                    LivesText.text = "Lives: " + NumberOfLives.ToString();
                    currentHealth = 100;
                    gameObject.GetComponent<TeleportorController>().manualTeleport();
                }
                else
                {
                    HealthText.text = "Health: 0";
                    GameOverMenu.SetActive(true);
                    Time.timeScale = 0;
                   
                }
            }
        }

        public void RemoveLife()
        {
            NumberOfLives = NumberOfLives - 1;
        }
    }

}
