using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game_settings : MonoBehaviour
{
    public float time_set = 300;
    public TextMeshProUGUI timeText;

    public void SetThreshold (float threshold)
    {
        PlayerPrefs.SetFloat("threshold", threshold);
    }
    public void SetCoinSpeed(float CoinSpeed)
    {
        PlayerPrefs.SetFloat("CoinSpeed", CoinSpeed);
    }
    public void SetCoinSpawn(float CoinSpawn)
    {
        PlayerPrefs.SetFloat("CoinSpawn", CoinSpawn);
    }
    public void SetGameDuration(float GameDuration)
    {
        PlayerPrefs.SetFloat("GameDuration", GameDuration);
    }

    private void Update()
    {
        time_set = PlayerPrefs.GetFloat("GameDuration", 300);
        float minutes = Mathf.FloorToInt(time_set / 60);
        float seconds = Mathf.FloorToInt(time_set % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
