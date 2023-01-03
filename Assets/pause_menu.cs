using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{
    
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public timer timer;
    void Start()
    {
        timer = FindObjectOfType<timer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (timer.timeRemaining !=0))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void reset()
    {
        SceneManager.LoadScene("main_scene");
        Time.timeScale = 1f;
    }

    public void quit_to_menu() 
    {
        SceneManager.LoadScene("main_menu");
        Time.timeScale = 1f;
    }
}
