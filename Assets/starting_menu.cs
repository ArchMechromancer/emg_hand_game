using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class starting_menu : MonoBehaviour
{
    public void play_game()
    {
        SceneManager.LoadScene("main_scene");
    }

    public void quit_game()
    {
        Application.Quit();
    }
}
