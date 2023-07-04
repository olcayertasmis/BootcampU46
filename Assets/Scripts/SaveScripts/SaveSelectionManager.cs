using UnityEngine;
using UnityEngine.SceneManagement;

namespace SaveScripts
{
    public class SaveSelectionManager : MonoBehaviour
    {
        public void LoadSelectedSave()
        {
            string selectedSlotName = SaveManager.Instance.GetSelectedSlotName();
            if (!string.IsNullOrEmpty(selectedSlotName))
            {
                SaveData saveData = SaveSystem.LoadGame(selectedSlotName);
                if (saveData != null)
                {
                    SceneManager.LoadScene(saveData.levelName);
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

        public void DeleteSelectedSave()
        {
            string selectedSlotName = SaveManager.Instance.GetSelectedSlotName();
            if (!string.IsNullOrEmpty(selectedSlotName))
            {
                //SaveSystem.DeleteSave(selectedSlotName);
                //SaveManager.Instance.RefreshSlotDropdown();
            }
            else
            {
                Debug.LogError("Kayıt seçilmedi!");
            }
        }
    }
}