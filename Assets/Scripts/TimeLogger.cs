using UnityEngine;
using System;
using System.IO;

public class PlayerDataManager : MonoBehaviour
{
    public PlayerData data;
    string path;

    void Start()
    {
        path = Path.Combine(Application.streamingAssetsPath, "player.json");
        data = GetComponent<StatsLoader>().data;
        SaveLoginTime();
    }

    void OnApplicationQuit()
    {
        #if !UNITY_EDITOR
        SaveLogoutTime();
        SaveData();
        #endif

    }


    void SaveLogoutTime()
    {
        data.datestamp.logged_off = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    void SaveLoginTime()
    {
        data.datestamp.logged_on = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    void SaveData()
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
}