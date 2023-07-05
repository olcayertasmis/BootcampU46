using System.IO;
using UnityEngine;

namespace SaveScripts
{
    public static class SaveSystem
    {
        private static string _savePath = Application.persistentDataPath + "/saves/";
        private static string _selectedSaveSlot;

        public static void SaveGameData(string slotName, SaveData data)
        {
            string filePath = _savePath + slotName + ".json";
            string jsonData = JsonUtility.ToJson(data);
            Directory.CreateDirectory(_savePath);
            File.WriteAllText(filePath, jsonData);
            Debug.Log("Game saved to: " + filePath);
        }

        public static SaveData LoadGameData(string slotName)
        {
            string filePath = _savePath + slotName + ".json";

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                SaveData data = JsonUtility.FromJson<SaveData>(jsonData);
                Debug.Log("Game loaded from: " + filePath);
                return data;
            }
            else
            {
                Debug.LogError("Save file not found: " + filePath);
                return null;
            }
        }

        public static bool IsSaveFileExists(string slotName)
        {
            string filePath = _savePath + slotName + ".json";

            return File.Exists(filePath);
        }

        public static string[] GetSaveSlotNames()
        {
            if (Directory.Exists(_savePath))
            {
                string[] fileNames = Directory.GetFiles(_savePath, "*.json");

                for (int i = 0; i < fileNames.Length; i++)
                {
                    fileNames[i] = Path.GetFileNameWithoutExtension(fileNames[i]);
                }

                return fileNames;
            }
            else return new string[0];
        }

        public static string GetLastSaveFileName()
        {
            string[] saveSlots = GetSaveSlotNames();

            return saveSlots.Length > 0 ? saveSlots[saveSlots.Length - 1] : null;
        }

        public static void SetSelectedSaveSlotName(string saveSlotName)
        {
            _selectedSaveSlot = saveSlotName;
        }

        public static string GetSelectedSaveSlotName()
        {
            return _selectedSaveSlot;
        }
    }
}