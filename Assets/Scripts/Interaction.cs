using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Interaction : MonoBehaviour
{
    public static int WalkSpeed;
    private Coroutine coroutine;
    private int preSpeed;
    public float boostDuration;
    public float delayDuration;
    private GameObject gameOverText;
    private GameObject meteorite;
    private GameObject restartButton;
    private GameObject redAlertButton;
    private GameObject exitButton;
    private GameObject timerText;
    private GameObject modeText;
    private GameObject chillModeButton;
    private float startTime;
    public Text timer;
    bool stopwatchActive = false;
    float currentTime = 0;
    float st;
    

    void Start()
    {
        restartButton = GameObject.Find("Restart Button");
        exitButton = GameObject.Find("Exit Button");
        timerText = GameObject.Find("Timer Text");
        gameOverText = GameObject.Find("Game Over Text");
        redAlertButton = GameObject.Find("Red Alert Button");
        meteorite = GameObject.Find("Meteorite");
        modeText = GameObject.Find("Mode Text");
        chillModeButton = GameObject.Find("Chill Mode Button");

        //mode screen
        redAlertButton.gameObject.SetActive(true);
        modeText.gameObject.SetActive(true);
        chillModeButton.gameObject.SetActive(true);
        timerText.gameObject.SetActive(false);
        meteorite.gameObject.SetActive(false);

        //restart scene
        restartButton.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        transform.position = transform.position + Camera.main.transform.forward * WalkSpeed * Time.deltaTime;

        if (WalkSpeed > 0)
        {
            StartStopwatch();
        }

        if (stopwatchActive == true)
        {
            modeText.gameObject.SetActive(false);
            chillModeButton.gameObject.SetActive(false);
            redAlertButton.gameObject.SetActive(false);
            timerText.gameObject.SetActive(true);
            currentTime = currentTime + Time.deltaTime;
        }
        string minutes = ((int)currentTime / 60).ToString();
        string seconds = (currentTime % 60).ToString("f2");

        timer.text =  minutes + "." + seconds;

    }

    void StartStopwatch()
    {
        stopwatchActive = true;
    }

    void StopStopwatch()
    {
        stopwatchActive = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boost"))
        {
            coroutine = StartCoroutine(Boost());
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            WalkSpeed = 0;
            other.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            timerText.gameObject.SetActive(false);
            StopStopwatch();
            coroutine = StartCoroutine(Delay(delayDuration));
        }
        
    }

    IEnumerator Boost()
    {
        preSpeed = WalkSpeed;
        WalkSpeed = 15;
        yield return new WaitForSeconds(boostDuration);
        WalkSpeed = preSpeed;
    }

    IEnumerator Delay(float delayDuration)
    {
        yield return new WaitForSeconds(delayDuration);
        meteorite.gameObject.SetActive(false);
       // Debug.Log("HERE" + Timer.num);
        restartButton.gameObject.SetActive(true);
        exitButton.gameObject.SetActive(true);
        gameOverText.GetComponent<Text>().text = "Game Over \n Your Time: " + "\n" + currentTime.ToString("n2") +"s";

        transform.position = new Vector3(-43, 1, -74);
    }
    
}
