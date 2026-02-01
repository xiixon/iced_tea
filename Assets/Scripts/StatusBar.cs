using UnityEngine;
using System.IO;

public class StatusBar : MonoBehaviour
{
    const int TWO_WEEKS = 1209600;
    public PlayerData data;

    void Start()
    {
        
    }

    void Update()
    {
        health = (data.datestamp.logged_off - data.datestamp.logged_on / TWO_WEEKS) * 100;
    }

}
