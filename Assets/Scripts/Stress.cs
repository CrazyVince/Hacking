using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stress : MonoBehaviour
{
    public float stress;
    public float stressGainRate;

    private void Update()
    {
        stress += stressGainRate * Time.deltaTime;
        if (stress >= 100f)
        {
            //lose
        }
    }
}
