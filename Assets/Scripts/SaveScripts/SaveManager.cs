using UnityEngine;

namespace SaveScripts
{
    public class SaveManager : MonoBehaviour
    {
        private static SaveManager instance;
        public static SaveManager Instance => instance;

        private string selectedSlotName;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public string GetSelectedSlotName()
        {
            return selectedSlotName;
        }

        public void SetSelectedSlotName(string slotName)
        {
            selectedSlotName = slotName;
        }
    }
}