using System.IO;
using UnityEngine;

namespace SaveScripts
{
    public static class SaveSystem
    {
        private const string SAVE_FOLDER = "SaveData";
        private const string FILE_EXTENSION = ".sav";

        public static void SaveGame(SaveData saveData, string slotName)
        {
            string filePath = GetSaveFilePath(slotName);
            string jsonData = JsonUtility.ToJson(saveData);
            File.WriteAllText(filePath, jsonData);
        }

        public static SaveData LoadGame(string slotName)
        {
            string filePath = GetSaveFilePath(slotName);
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                SaveData saveData = JsonUtility.FromJson<SaveData>(jsonData);
                return saveData;
            }
            else
            {
                Debug.LogWarning("Kayıtlı veri bulunamadı: " + slotName);
                return null;
            }
        }

        public static string[] GetSaveSlotNames()
        {
            string[] files = Directory.GetFiles(GetSaveFolderPath(), "*" + FILE_EXTENSION);
            string[] slotNames = new string[files.Length];
            for (int i = 0; i < files.Length; i++)
            {
                slotNames[i] = Path.GetFileNameWithoutExtension(files[i]);
            }
            return slotNames;
        }

        public static string GetLastSaveFileName()
        {
            string[] slotNames = GetSaveSlotNames();
            if (slotNames.Length > 0)
            {
                return slotNames[slotNames.Length - 1];
            }
            else
            {
                return string.Empty;
            }
        }

        private static string GetSaveFolderPath()
        {
            return Path.Combine(Application.persistentDataPath, SAVE_FOLDER);
        }

        private static string GetSaveFilePath(string slotName)
        {
            string saveFolderPath = GetSaveFolderPath();
            if (!Directory.Exists(saveFolderPath))
            {
                Directory.CreateDirectory(saveFolderPath);
            }
            return Path.Combine(saveFolderPath, slotName + FILE_EXTENSION);
        }
    }
}
