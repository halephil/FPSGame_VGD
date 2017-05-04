using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

   public class HealthManager : MonoBehaviour {
        public GameObject GameOverMenu;
        public int MaxHealth;
        public int NumberOfLives;
        private int currentHealth;
        public int AllosaurusDamage;
        public int BossDamage;
       
        public Text HealthText;
        public Text LivesText;

        public Image damageImage;
        public float flashSpeed = 5f;
        public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
        bool damaged;
        public AudioClip hurt;


        // Use this for initialization
        void Start() {
           
            currentHealth = MaxHealth;
            LivesText.text = "Lives: " + NumberOfLives.ToString();
            HealthText.text = "Health: " + currentHealth.ToString();
           
        }

        // Update is called once per frame
        void Update() {
            checkHealth();
            if (damaged)
            {
                // ... set the colour of the damageImage to the flash colour.
                damageImage.color = flashColour;
                GetComponent<AudioSource>().PlayOneShot(hurt);
            }
            // Otherwise...
            else
            {
                // ... transition the colour back to clear.
                damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            }
            damaged = false;
        }

        private void OnTriggerEnter(Collider other)
        {
         
            // Debug.Log(other.transform.tag);
            if (other.transform.tag == "Dino")
            {
                
                if (other.gameObject.GetComponent<Animation>().IsPlaying("Allosaurus_Attack02") == true)
                {
                    if (currentHealth > 0)
                    {
                        damaged = true;
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
                        damaged = true;
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

        public void takeDamage(int damage){
            currentHealth -= damage;
            damaged = true;
            HealthText.text = "Health: " + currentHealth.ToString();
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

