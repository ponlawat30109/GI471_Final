using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    //public enum InputType
    //{
    //    Target,
    //    NoneTarget,
    //}

    //public InputType inputType;

    [SerializeField]
    private float timer = 60.0f/*, activeTimer = 2.0f*/;
    private int randomActiveTarget;
    public int score = 0;
    

    public static GameSystem instance;

    public delegate void DelegateHandle(string input);
    public DelegateHandle OnInput, OnTimer;

    public GameObject[] targetButton;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (var i = 0; i < targetButton.Length; i++)
        {
            targetButton[i].SetActive(false);
        }
        SetRandomActive();
    }

    private void Update()
    {
        Timer();
        targetButton[randomActiveTarget].GetComponent<Button>().onClick.AddListener(OnButtonClick);
        StartCoroutine(StartDoing());
    }

    public IEnumerator StartDoing()
    {
        yield return new WaitForSeconds(5);
        randomActiveTarget = Random.Range(0, targetButton.Length);
        Debug.Log(randomActiveTarget);
    }

    public void SetRandomActive()
    {
        randomActiveTarget = Random.Range(0, targetButton.Length);
        targetButton[randomActiveTarget].SetActive(true);
    }

    public void OnButtonClick()
    {
        targetButton[randomActiveTarget].SetActive(false);
        //Debug.Log("Target Click");
        SetRandomActive();
    }

    public void Timer()
    {
        timer -= Time.deltaTime;

        //activeTimer -= Time.deltaTime;
        //if (activeTimer <= 0)
        //{
        //    targetButton[randomActiveTarget].SetActive(false);
        //    Debug.Log("Target Lost");
        //    activeTimer = 1.0f;
        //}

        if (timer <= 0)
        {
            SceneManager.LoadScene("ResultScene");
        }

        OnTimer(timer.ToString("F"));
    }

    public void InputData(string inputStr)
    {
        if (inputStr == "1")
        {
            score += 1;

            Debug.Log(score);
        }

        if (inputStr == "2")
        {
            score -= 2;

            Debug.Log(score);
        }

        OnInput(score.ToString());
    }
}
