using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SaveScripts
{
    public class SaveTrigger : MonoBehaviour
    {
        public GameObject saveMenu;
        public GameObject slotList;
        public Button saveButton;
        public Button cancelButton;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                saveMenu.SetActive(true);
                RefreshSlotList();
                saveButton.onClick.RemoveAllListeners();
                saveButton.onClick.AddListener(SaveGame);
                cancelButton.onClick.AddListener(CloseMenu);
            }
        }

        private void SaveGame()
        {
            SaveData data = new SaveData();
            // Verileri doldurun: data.keyCount, data.levelName, data.position

            // Slot adını alın
            string slotName = slotList.GetComponent<Dropdown>().options[slotList.GetComponent<Dropdown>().value].text;

            SaveSystem.SaveGame(slotName, data);
            CloseMenu();
        }

        private void CloseMenu()
        {
            saveMenu.SetActive(false);
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