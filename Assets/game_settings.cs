using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class game_settings : MonoBehaviour
{
    public float time_set = 300;
    public float speed_set = 2;
    public float interval_set = 2;
    public float threshold_set = 3;

    public TextMeshProUGUI timeText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI intervalText;
    public TextMeshProUGUI thresholdText;

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

        speed_set = PlayerPrefs.GetFloat("CoinSpeed", 2);
        speedText.text = speed_set.ToString();

        interval_set = PlayerPrefs.GetFloat("CoinSpawn", 2);
        intervalText.text = interval_set.ToString();

        threshold_set = PlayerPrefs.GetFloat("threshhold", 3);
        thresholdText.text = threshold_set.ToString();  
    }
}
