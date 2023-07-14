using System;
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
    public GameObject InventoryMenuPanel;
    public GameObject MinimapMenuPanel;
    public GameObject ActionBarPanel;
    private bool isPaused = false;
    private bool isGameStarted = false;

    private void Awake()
    {
        //ActionBarPanel.SetActive(true);
    }

    private void Start()
    {
        //ActionBarPanel.SetActive(true);
        //MainMenuPanel.SetActive(true);      
        //PauseMenuPanel.SetActive(false);
        //OptionsMenuPanel.SetActive(false);
    }
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
            Debug.Log("PauseMenuPanel");
            ActionBarPanel.SetActive(false);
        } 
        else if(panel == "ResumeButton")
        {
            ResumeGame();
        }
        else if(panel == "OptionsButton")
        {
            OptionsMenuPanel.SetActive (true);
            ActionBarPanel.SetActive (false);
            //MainMenuPanel.SetActive (false);
            //PauseMenuPanel.SetActive (false);
        }
        if (panel == "BackButton")
        {
            ResumeGame();
        }
        if (panel == "InventoryMenuPanel")
        {
            if (!isPaused)
            {
                PauseGame();
                ActionBarPanel.SetActive(true);
            }
            InventoryMenuPanel.SetActive(true);

        }
        else if (panel == "ActionBarPanel")//Oyun ba�lad�ktan sonra di�er paneller �al���rken(Inventory d���nda) ActionMenuPanel kapans�n Yoksa hep a��k dursun.(YAZAMADIM)
        {
            ActionBarPanel.SetActive(true);
            
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        if (!isGameStarted)
        {
            isGameStarted = true;
            MainMenuPanel.SetActive(false);
            ActionBarPanel.SetActive(true);
        }
        //else if (!isGameStarted)
        //{
        //    isGameStarted = true;
            
        //}
    }
    
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Oyun zaman�n� durdur
        PauseMenuPanel.SetActive(true);
        Debug.Log("PauseGame");
        ActionBarPanel.SetActive(false);
    }
    public void OptionsGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        OptionsMenuPanel.SetActive(true);
        Debug.Log("OptionsGame");
        ActionBarPanel.SetActive(false);
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Oyun zaman�n� tekrar ba�lat
        PauseMenuPanel.SetActive(false); 
        OptionsMenuPanel.SetActive(false );
        InventoryMenuPanel.SetActive(false);
        ActionBarPanel.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
