using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameLevelManager : MonoBehaviour {

    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public GameObject WinMenu;
    //public GameObject UnPausescreen;
    //public Button PauseButton;
    public Button UnPauseButton;
    public Button RestartGameButton;
    public Button ReturnToMainMenu;
    public Button QuitGame;
    public bool pauseState;


	// Use this for initialization
	void Start () {
        //PauseButton.GetComponent<Button>().onClick.AddListener(PauseButtonHandler);
        UnPauseButton.GetComponent<Button>().onClick.AddListener(UnPauseButtonHandler);
        RestartGameButton.GetComponent<Button>().onClick.AddListener(RestartGameButtonHandler);
        ReturnToMainMenu.GetComponent<Button>().onClick.AddListener(ReturnToMainMenuHandler);
        QuitGame.GetComponent<Button>().onClick.AddListener(QuitGameHandler);

    }

    // Update is called once per frame
    void Update() {
        if (GameOverMenu.activeSelf == false || WinMenu.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (Time.timeScale == 1)
                {
                    PauseButtonHandler();
                    Time.timeScale = 0;
                }
                else
                {
                    PauseButtonHandler();
                    Time.timeScale = 1;
                }
            }
        }
        if (PauseMenu.activeSelf == true || GameOverMenu.activeSelf == true || WinMenu.activeSelf == true )
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Time.timeScale = 1;
                QuitGameHandler();
               
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1;
                RestartGameButtonHandler();
              
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 1;
                ReturnToMainMenuHandler();
               
            }
        }


    }

    void PauseButtonHandler()
    {
        // UnPausescreen.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        pauseState = !pauseState;

    }
    void UnPauseButtonHandler()
    {
       
        
       
        PauseMenu.SetActive(false);
        pauseState = false;
    }

    void RestartGameButtonHandler()
    {
        Application.LoadLevel("Level");
    }

    void ReturnToMainMenuHandler()
    {
        Application.LoadLevel("Main Menu");
    }

    void QuitGameHandler()
    {
        Application.Quit();
    }
}
