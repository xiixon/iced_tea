using UnityEngine;
using System.IO;

public class StatsLoader : MonoBehaviour
{
    public PlayerData data;

    void Start()
    {
        LoadData();

        Debug.Log("Hunger: " + data.status.hunger);
        Debug.Log("Thirst: " + data.status.thirst);
    }

    void LoadData()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "player.json");

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            Debug.LogError("JSON file not found at: " + path);
        }
    }
}
