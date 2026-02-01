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
        LoadData();
        SaveLoginTime();
    }

    void OnApplicationQuit()
    {
        SaveLogoutTime();
        SaveData();
    }


    void SaveLogoutTime()
    {
        data.datestamp.logged_off = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    void SaveLoginTime()
    {
        data.datestamp.logged_on = (int)DateTimeOffset.UtcNow.ToUnixTimeSeconds();
    }

    void LoadData()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<PlayerData>(json);
        }
    }

    void SaveData()
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }
}