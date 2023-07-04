using System.Collections;
using System.Collections.Generic;
using SaveScripts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private int keyCount;
    private string levelName;
    private Vector3 playerPosition;

    private GameObject playerPrefab;
    private GameObject currentPlayer;

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
        keyCount = saveData.keyCount;
        levelName = saveData.levelName;
        playerPosition = saveData.position;
    }

    public int GetKeyCount()
    {
        return keyCount;
    }

    public string GetLevelName()
    {
        return levelName;
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }
}