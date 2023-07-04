using Cinemachine;
using SaveScripts;
using UnityEngine;

namespace Player_Scripts
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject playerPrefab;
        private CinemachineFreeLook _cinemachineFreeLook;

        private void Awake()
        {
            _cinemachineFreeLook = FindObjectOfType<CinemachineFreeLook>();

            LoadSavedPlayer();
        }

        private void LoadSavedPlayer()
        {
            string selectedSlotName = SaveSystem.GetLastSaveFileName();
            if (!string.IsNullOrEmpty(selectedSlotName))
            {
                SaveData saveData = SaveSystem.LoadGame(selectedSlotName);
                if (saveData != null)
                {
                    if (playerPrefab != null)
                    {
                        Vector3 playerPosition = saveData.position;
                        Quaternion playerRotation = Quaternion.identity;

                        GameObject spawnedPrefab = Instantiate(playerPrefab, playerPosition, playerRotation);

                        _cinemachineFreeLook.LookAt = spawnedPrefab.transform;
                        _cinemachineFreeLook.Follow = spawnedPrefab.transform;
                    }
                    else
                    {
                        Debug.LogError("Player prefabı yüklenemedi!");
                    }
                }
                else
                {
                    Debug.LogError("Kayıtlı veri bulunamadı!");
                }
            }
            else
            {
                Debug.LogError("Kayıt bulunamadı!");
            }
        }
    }
}