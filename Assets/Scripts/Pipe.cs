using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public bool smoking;
    public float stressReduction;
    public float maxSmokeTime;
    public float smokeTimeLeft;
    public GameObject model;
    public GameObject holdingModel;
    public Stress stress;

    private void Update()
    {
        if (smoking)
        {
            smokeTimeLeft -= Time.deltaTime;
            if (smokeTimeLeft <= 0)
            {
                FinishSmoking();
            }
        }
    }

    public void Smoke()
    {
        smoking = true;
        smokeTimeLeft = maxSmokeTime;
        model.SetActive(false);
        holdingModel.SetActive(true);
    }

    void FinishSmoking()
    {
        smoking = false;
        model.SetActive(true);
        holdingModel.SetActive(false);
        stress.stress -= stressReduction;
    }
}
