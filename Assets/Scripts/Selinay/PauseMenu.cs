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
    //private bool isMinimapOpen = false;

    private void Start()
    {
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
        else if (panel == "ActionBarPanel")//Oyun baþladýktan sonra diðer paneller çalýþýrken(Inventory dýþýnda) ActionMenuPanel kapansýn Yoksa hep açýk dursun.(YAZAMADIM)
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
        }
        else if (!isGameStarted)
        {
            isGameStarted = true;
            ActionBarPanel.SetActive(true);
        }
    }
    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Oyun zamanýný durdur
        PauseMenuPanel.SetActive(true);       
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Oyun zamanýný tekrar baþlat
        PauseMenuPanel.SetActive(false);        
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
