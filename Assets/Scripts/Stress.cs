using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stress : MonoBehaviour
{
    public float stress;
    public float stressGainRate;

    public Image bar;

    private void Update()
    {
        stress += stressGainRate * Time.deltaTime;
        bar.fillAmount = stress / 100;

        if (stress >= 100f)
        {
            //lose
        }
    }
}
