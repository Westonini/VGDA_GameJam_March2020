using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    static bool showStartMenu = true;
    public GameObject startMenu;

    void Start()
    {
        if (showStartMenu)
        {
            AudioManager.instance.Play("Theme");

            startMenu.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;

        showStartMenu = false;
    }
}
