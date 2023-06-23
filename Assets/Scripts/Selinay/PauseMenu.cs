using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused;
    public GameObject canvasPause;
    private Toggle _MapToggle;
    public GameObject minimap;
    private Toggle _MenuToggle;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Resume()
    {
        canvasPause.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void Pause()
    {
        canvasPause.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
    private void Awake()
    {
        _MenuToggle = GetComponent<Toggle>();
        _MapToggle = minimap.GetComponentInChildren<Toggle>();
    }
    public void MenuOn()
    {

        Time.timeScale = 0;

        minimap.gameObject.SetActive(false);
    }
    public void MenuOff()
    {

        minimap.gameObject.SetActive(true);
        if (_MapToggle.isOn)
        {
            _MapToggle.isOn = false;
        }
    }
}
