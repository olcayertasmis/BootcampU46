using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SaveScripts
{
    [System.Serializable]
    public class SaveData
    {
        public int keyCount;
        public string levelName;
        public Vector3 position;
    }

    public static class SaveSystem
    {
        private static string _savePath = "/save.json";

        public static void SaveGame(string slotName, SaveData data)
        {
            string json = JsonUtility.ToJson(data);
            File.WriteAllText(GetSavePath(slotName), json);
        }

        public static SaveData LoadGame(string slotName)
        {
            string path = GetSavePath(slotName);
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                return JsonUtility.FromJson<SaveData>(json);
            }
            else
            {
                Debug.Log("Save file not found!");
                return null;
            }
        }

        public static List<string> GetSaveSlots()
        {
            List<string> saveSlots = new List<string>();

            DirectoryInfo directoryInfo = new DirectoryInfo(Application.persistentDataPath);
            FileInfo[] files = directoryInfo.GetFiles("*.json");
            foreach (FileInfo file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.Name);
                saveSlots.Add(fileName);
            }

            return saveSlots;
        }

        private static string GetSavePath(string slotName)
        {
            return Application.persistentDataPath + "/" + slotName + ".json";
        }
    }
}