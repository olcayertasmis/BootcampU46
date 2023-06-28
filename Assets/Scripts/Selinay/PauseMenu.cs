using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuPanel;
    public GameObject MainMenuPanel;
    public GameObject OptionsMenuPanel;
    public GameObject MinimapMenuPanel;
    private bool isPaused = false;
    private bool isGameStarted = false;
    //private bool isMinimapOpen = false;

    //private void Start()
    //{
    //    MainMenuPanel.SetActive(false);   //true yapýlacak   
    //    PauseMenuPanel.SetActive(false);
    //    OptionsMenuPanel.SetActive(false);
    //}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void OpenButton(string panel)
    {
        if(panel == "PauseMenuPanel")
        {
            PauseGame();
        } 
        else if(panel == "ResumeButton")
        {
            ResumeGame();
        }
        else if(panel == "OptionsButton")
        {
            OptionsMenuPanel.SetActive (true);
            //MainMenuPanel.SetActive (false);
            //PauseMenuPanel.SetActive (false);
        }
        if (panel == "MinimapMenuPanel")
        {
            //PauseGame();
        }
        //else if(panel == "BackButton")
        //{
        //    if (isMinimapOpen)
        //    {
        //        Time.timeScale = 0f;
        //    }
        //    else
        //    {
        //        ResumeGame();
        //    }
        //}
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (!isGameStarted)
        {
            isGameStarted = true;
            MainMenuPanel.SetActive(false);                       
        }
    }
    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Oyun zamanýný durdur
        PauseMenuPanel.SetActive(true);       
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Oyun zamanýný tekrar baþlat
        PauseMenuPanel.SetActive(false);        
    }

}
