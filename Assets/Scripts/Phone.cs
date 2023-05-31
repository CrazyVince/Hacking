using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public bool ringing;
    public bool talking;
    public bool talked;
    public float MaxTalkTime;
    public float talkTimeLeft;
    public float maxRingTime;
    public float ringTimeLeft;
    public Interact interact;
    public GameObject holdPhoneModel;
    public GameObject model;
    public AudioSource audio;
    public Computer computer;

    private void Update()
    {
        if (talking)
        {
            talkTimeLeft -= Time.deltaTime;
            if (talkTimeLeft <= 0)
            {
                PutDown();
            }
        }

        if (ringing)
        {
            ringTimeLeft -= Time.deltaTime;
            if (ringTimeLeft <= 0)
            {
                //fail
                print("you didint answer the phone.");
            }
        }
    }

    public void StartRinging()
    {
        if (!computer.hacked)
        {
            //fail
            print("you didint hack the system before the next call.");
        }

        ringing = true;
        ringTimeLeft = maxRingTime;
        audio.enabled = true;
    }

    public void PickUp()
    {
        if (!ringing) return;

        ringing = false;
        talking = true;
        interact.enablePhone = false;
        interact.enableDoor = false;
        interact.enableHack = false;
        model.SetActive(false);
        holdPhoneModel.SetActive(true);
        talkTimeLeft = MaxTalkTime;
        audio.enabled = false;
    }

    public void PutDown()
    {
        talking = false;
        interact.enablePhone = true;
        interact.enableDoor = true;
        interact.enableHack = true;
        model.SetActive(true);
        holdPhoneModel.SetActive(false);
        talked = true;
        computer.needHack = true;
        computer.hacked = false;
    }
}
