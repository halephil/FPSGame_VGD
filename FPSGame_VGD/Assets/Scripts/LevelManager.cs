using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    public GameObject Mcamera;
    public GameObject FirstMenu;
    public GameObject SecondMenu;
    public Button playButton;
    public Button instructionButton;
    public Button quitButton;
    public Button returnToMainMenuButton;
    private bool POSoneReached, POStwoReached;
   
   
    private float currentTime;


	// Use this for initialization
	void Start () {
        POSoneReached = true;
        POStwoReached = false;
        playButton.GetComponent<Button>().onClick.AddListener(playButtonHandler);
        instructionButton.GetComponent<Button>().onClick.AddListener(instructionButtonHandler);
        quitButton.GetComponent<Button>().onClick.AddListener(quitButtonHandler);
        returnToMainMenuButton.GetComponent<Button>().onClick.AddListener(returnToMainMenuHandler);
        Mcamera.transform.position = new Vector3(19, 3.5f, -0.6f);
    }
	
	// Update is called once per frame
	void Update () {
        moveMenu();
	}

   
    void playButtonHandler()
    {
        Application.LoadLevel("Level");
    }

    void instructionButtonHandler()
    {
        FirstMenu.SetActive(false);
        POSoneReached = false;
        POStwoReached = true;
    }

    void quitButtonHandler()
    {
        Application.Quit();
    }

    void returnToMainMenuHandler()
    {
        SecondMenu.SetActive(false);
        POSoneReached = true;
        POStwoReached = false;
    }


    void moveMenu()
    {
       if((FirstMenu.activeSelf == false) && (POSoneReached == true))
        {
            currentTime = currentTime + (Time.deltaTime/50);
            if (Mcamera.transform.position.x >= 19)
            {            
                Mcamera.transform.position = new Vector3(Mcamera.transform.position.x - currentTime, Mcamera.transform.position.y, Mcamera.transform.position.z);
            }

            if (Mcamera.transform.position.y >= 3.5)
            {
                Mcamera.transform.position = new Vector3(Mcamera.transform.position.x, Mcamera.transform.position.y - currentTime, Mcamera.transform.position.z);
            }

            if (Mcamera.transform.position.z >= -0.6 )
            {
                Mcamera.transform.position = new Vector3(Mcamera.transform.position.x, Mcamera.transform.position.y, Mcamera.transform.position.z - currentTime);
            }

            if (Mcamera.transform.position.x <= 19  && Mcamera.transform.position.y <= 3.5 && Mcamera.transform.position.z <= -0.6)
            {
                currentTime = 0;
                FirstMenu.SetActive(true);
               
            }



        }

        if ((SecondMenu.activeSelf == false) && (POStwoReached == true))
        {
            currentTime = currentTime + (Time.deltaTime / 50);
            if (Mcamera.transform.position.x <= 24.31)
            {
                Mcamera.transform.position = new Vector3(Mcamera.transform.position.x + currentTime, Mcamera.transform.position.y, Mcamera.transform.position.z);
            }

            if (Mcamera.transform.position.y <= 5.6)
            {
                Mcamera.transform.position = new Vector3(Mcamera.transform.position.x, Mcamera.transform.position.y + currentTime, Mcamera.transform.position.z);
            }

            if (Mcamera.transform.position.z <= 0)
            {
                Mcamera.transform.position = new Vector3(Mcamera.transform.position.x, Mcamera.transform.position.y, Mcamera.transform.position.z + currentTime);
            }

            if (Mcamera.transform.position.x >= 24.31 && Mcamera.transform.position.y >= 5.6 && Mcamera.transform.position.z >= 0)
            {
                currentTime = 0;
                SecondMenu.SetActive(true);
                
            }



        }
    }


}
