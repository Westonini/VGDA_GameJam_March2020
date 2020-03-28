using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private Animator gameOverAnim;

    private void Awake()
    {
        gameOverAnim = GetComponent<Animator>();
    }

    public void StartGameOver()
    {
        Time.timeScale = 0f;
        AudioListener.pause = true;
        gameOverAnim.SetBool("Activate", true);
    }

    //RETRY BUTTON
    public void Retry()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
