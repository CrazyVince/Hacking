using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.ExceptionServices;

public class Computer : MonoBehaviour
{
    public int maxLetters;
    public float maxTime;
    public bool needHack;
    public bool hacked;
    public FirstPersonLook mouseLook;
    public FirstPersonMovement movement;
    public GameObject screen;
    public TextMeshProUGUI letterText;
    public TextMeshProUGUI quicklyText;
    public TextMeshProUGUI timerText;
    public Interact interact;

    bool hacking = false;
    int lettersLeft;
    float timeLeft;

    private void Update()
    {
        if (hacking)
        {
            char currentLetter = letterText.text[0];
            if (Input.GetKeyDown(currentLetter.ToString().ToLower())){
                letterText.text = ((char)Random.Range(65, 90)).ToString();
                lettersLeft--;

                if (lettersLeft == 0)
                {
                    quicklyText.text = "SUCCESS";
                    hacking = false;
                    letterText.text = "";
                    hacked = true;
                    needHack = false;
                    Invoke(nameof(FinishHacking), 1);
                }
            }

            timerText.text = $"time left: {timeLeft.ToString("#.##")}";

            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                quicklyText.color = Color.red;
                quicklyText.text = "ACCESS DENIED";
                timerText.text = "time left: 0.00";
                hacking = false;
                letterText.text = "";
                Invoke(nameof(FinishHacking), 1);
            }
        }
    }

    public void StartHacking()
    {
        if (!needHack) return;

        mouseLook.enabled = false;
        movement.enabled = false;
        interact.enableHack = false;
        screen.SetActive(true);

        hacking = true;

        lettersLeft = maxLetters;
        timeLeft = maxTime;
        letterText.text = ((char)Random.Range(65, 90)).ToString();

        quicklyText.text = "Quickly! press:";
        quicklyText.color = Color.green;
    }

    void FinishHacking()
    {
        mouseLook.enabled = true;
        movement.enabled = true;
        interact.enableHack = true;
        
        screen.SetActive(false);
    }
}
