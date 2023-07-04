using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SaveScripts
{
    public class SaveTrigger : MonoBehaviour
    {
        public GameObject saveMenu;
        public GameObject player;
        public InputField slotNameInputField;

        private bool isTriggered = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == player && !isTriggered)
            {
                isTriggered = true;
                OpenSaveMenu();
            }
        }

        private void OpenSaveMenu()
        {
            saveMenu.SetActive(true);
        }

        public void SaveGame()
        {
            SaveData data = new SaveData();
            //data.keyCount = PlayerInventory.Instance.GetKeyCount();
            data.levelName = SceneManager.GetActiveScene().name;
            data.position = transform.position; // SaveTrigger'ın pozisyonunu alır

            string slotName = slotNameInputField.text;

            SaveSystem.SaveGame(data, slotName);
            CloseSaveMenu();
        }

        public void CloseSaveMenu()
        {
            saveMenu.SetActive(false);
        }
    }
}