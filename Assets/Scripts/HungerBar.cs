using UnityEngine;
using System.IO;

public class HungerBar : MonoBehaviour
{
    const int ONE_WEEK = 604800;
    public PlayerData data;
    public float hunger;
    public float health_decrease;
    private float maxWidth;
    private RectTransform rect;
    string path;
    public float maxHunger;
    public float previous_hunger;

    void Start()
    {
        path = Path.Combine(Application.streamingAssetsPath, "player.json");
        data = GameObject.Find("StatsLoader").GetComponent<StatsLoader>().data;
        maxHunger = 100;
        health_decrease = (data.datestamp.logged_on - data.datestamp.logged_off) / ONE_WEEK * 100;
        previous_hunger = data.status.hunger;
        hunger = Mathf.Clamp(previous_hunger - health_decrease, 0, maxHunger);
        rect = GetComponent<RectTransform>();
        maxWidth = rect.sizeDelta.x;
    }

    void Update()
    {
        float normalized = hunger / maxHunger;
        rect.sizeDelta = new Vector2(maxWidth * normalized, rect.sizeDelta.y);
    }


}
