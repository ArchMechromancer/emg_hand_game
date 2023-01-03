using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timer : MonoBehaviour
{
    public float time_set = 300;
    public bool timerIsRunning = false;
    public float timeRemaining = 300;
    public TextMeshProUGUI timeText;

    public GameObject end_menu;
    // Start is called before the first frame update
    void Start()
    {
        time_set = PlayerPrefs.GetFloat("GameDuration", 300);
        timerIsRunning = true;
        timeRemaining = time_set;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                end_menu.SetActive(true);
                Time.timeScale = 0;
                
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
