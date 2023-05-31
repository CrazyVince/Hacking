using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class LevelManager : MonoBehaviour
{
    public Phone phone;
    public float phoneRingInterval;

    float timeUntilRing;

    private void Start()
    {
        timeUntilRing = phoneRingInterval;
    }

    private void Update()
    {
        timeUntilRing -= Time.deltaTime;
        if (timeUntilRing <= 0 ) 
        {
            phone.StartRinging();
            timeUntilRing = phoneRingInterval;
        }
    }
}
