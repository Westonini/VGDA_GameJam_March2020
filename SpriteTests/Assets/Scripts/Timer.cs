using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    private TextMeshProUGUI timerText;

    public GameOver gameOver;

    private void Awake()
    {
        timerText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            timerText.text = Mathf.Round(timeLeft).ToString();
        }
        else if (timeLeft < 0 && Time.timeScale != 0)
        {
            timeLeft = 0;
            gameOver.StartGameOver();
        }
    }
}
