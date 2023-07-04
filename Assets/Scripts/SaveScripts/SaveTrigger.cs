using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace SaveScripts
{
    public class SaveTrigger : MonoBehaviour
    {
        [SerializeField] private GameObject saveMenu;
        [SerializeField] private InputField slotNameInputField;

        private bool _isTriggered;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player") || _isTriggered) return;

            _isTriggered = true;
            OpenSaveMenu();
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

            SaveSystem.SaveGameData(slotName, data);
            CloseSaveMenu();
        }

        public void CloseSaveMenu()
        {
            saveMenu.SetActive(false);
        }
    }
}