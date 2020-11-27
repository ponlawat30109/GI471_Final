using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text scoreText,timeText;

    void Start()
    {
        GameSystem.instance.OnInput += OnInput;
        GameSystem.instance.OnTimer += OnTimer;
    }

    void Update()
    {
        
    }
    public void OnInput(string input)
    {
        scoreText.text = "Score : " + input;
    }

    public void OnTimer(string input)
    {
        timeText.text = "Time : " + input;
    }
}
