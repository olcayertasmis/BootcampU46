using System.IO;
using UnityEngine;

namespace SaveScripts
{
    public static class SaveSystem
    {
        private static string savePath = Application.persistentDataPath + "/saves/";

        public static void SaveGame(string slotName, SaveData data)
        {
            string filePath = savePath + slotName + ".json";
            string jsonData = JsonUtility.ToJson(data);
            Directory.CreateDirectory(savePath);
            File.WriteAllText(filePath, jsonData);
            Debug.Log("Game saved to: " + filePath);
        }

        public static SaveData LoadGame(string slotName)
        {
            string filePath = savePath + slotName + ".json";
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
            string filePath = savePath + slotName + ".json";
            return File.Exists(filePath);
        }

        public static string[] GetSaveSlotNames()
        {
            if (Directory.Exists(savePath))
            {
                string[] fileNames = Directory.GetFiles(savePath, "*.json");
                for (int i = 0; i < fileNames.Length; i++)
                {
                    fileNames[i] = Path.GetFileNameWithoutExtension(fileNames[i]);
                }

                return fileNames;
            }
            else
            {
                return new string[0];
            }
        }

        public static string GetLastSaveFileName()
        {
            string[] saveSlots = GetSaveSlotNames();
            if (saveSlots.Length > 0)
            {
                return saveSlots[saveSlots.Length - 1];
            }
            else
            {
                return null;
            }
        }
    }
}
