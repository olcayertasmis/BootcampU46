using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SaveScripts
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject loadMenu;
        public GameObject slotList;
        public Button continueButton;

        private void Start()
        {
            continueButton.gameObject.SetActive(SaveSystem.GetSaveSlots().Count > 0);
        }

        public void LoadGame()
        {
            loadMenu.SetActive(true);
            RefreshSlotList();
        }

        public void ContinueGame()
        {
            List<string> saveSlots = SaveSystem.GetSaveSlots();
            if (saveSlots.Count > 0)
            {
                string latestSlot = saveSlots[saveSlots.Count - 1];
                LoadGameFromSlot(latestSlot);
            }
        }

        public void LoadGameFromSlot(string slotName)
        {
            SaveData data = SaveSystem.LoadGame(slotName);
            if (data != null)
            {
                SceneManager.LoadScene(data.levelName);
                // Karakterin pozisyonunu data.position olarak ayarlayın
            }
        }

        public void CloseLoadMenu()
        {
            loadMenu.SetActive(false);
        }

        private void RefreshSlotList()
        {
            Dropdown dropdown = slotList.GetComponent<Dropdown>();
            dropdown.ClearOptions();

            List<string> saveSlots = SaveSystem.GetSaveSlots();
            dropdown.AddOptions(saveSlots);
        }
    }
}