using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultSystem : MonoBehaviour
{
    public Text scoreText;
    void Start()
    {
        scoreText.text = "" + GameSystem.instance.score;
    }
}
