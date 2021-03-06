﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ProgressBarController : MonoBehaviour
{ 
    void Start()
    {
        Slider.value = GlobalData.ProgressBarValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.ProgressDone > 0)
        {
            FillProgressBar(GlobalData.ProgressDone);
            GlobalData.ProgressDone = 0;
        }
    }


    public Slider Slider;

    public void FillProgressBar(int procentage)
    {
        StartCoroutine(FillBar(100/9 * procentage));
    }
    IEnumerator FillBar(int procentage)
    {
        //float runtime = 1f;
        for (int i = 0; i < procentage; i++)
        {
            Slider.value += (float)0.01;
            GlobalData.ProgressBarValue = Slider.value;
            yield return null;
        }
    }
}
