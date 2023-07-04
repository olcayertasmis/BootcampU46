using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SaveScripts;

public class MainMenuSave : MonoBehaviour
{
    public GameObject loadMenu;
    public Dropdown slotDropdown;

    private void Start()
    {
        RefreshSlotDropdown();
    }

    public void StartGame()
    {
        StartCoroutine(StartGameCoroutine());
    }

    private IEnumerator StartGameCoroutine()
    {
        string selectedSlotName = GetSelectedSlotName();
        if (!string.IsNullOrEmpty(selectedSlotName))
        {
            SaveData saveData = SaveSystem.LoadGame(selectedSlotName);
            if (saveData != null)
            {
                GameManager.Instance.SetGameData(saveData);

                yield return SceneManager.LoadSceneAsync(saveData.levelName);
            }
            else
            {
                Debug.LogError("Kayıtlı veri bulunamadı!");
            }
        }
        else
        {
            Debug.LogError("Kayıt seçilmedi!");
        }
    }

    public void ContinueGame()
    {
        string lastSaveFileName = SaveSystem.GetLastSaveFileName();
        if (!string.IsNullOrEmpty(lastSaveFileName))
        {
            SaveData saveData = SaveSystem.LoadGame(lastSaveFileName);
            if (saveData != null)
            {
                GameManager.Instance.SetGameData(saveData);

                StartCoroutine(LoadGameCoroutine(saveData));
                loadMenu.SetActive(false);
            }
            else
            {
                Debug.LogError("Kayıtlı veri bulunamadı!");
            }
        }
        else
        {
            Debug.LogError("Kayıt bulunamadı!");
        }
    }

    private IEnumerator LoadGameCoroutine(SaveData saveData)
    {
        yield return SceneManager.LoadSceneAsync(saveData.levelName);
    }

    public void RefreshSlotDropdown()
    {
        string[] slotNames = SaveSystem.GetSaveSlotNames();
        slotDropdown.ClearOptions();
        slotDropdown.AddOptions(new List<string>(slotNames));
    }

    public string GetSelectedSlotName()
    {
        return slotDropdown.options[slotDropdown.value].text;
    }
}
