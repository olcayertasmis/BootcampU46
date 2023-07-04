using SaveScripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Save Data")]
    private int _keyCount;
    private string _levelName;
    private Vector3 _playerPosition;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetGameData(SaveData saveData)
    {
        _keyCount = saveData.keyCount;
        _levelName = saveData.levelName;
        _playerPosition = saveData.position;
    }
}