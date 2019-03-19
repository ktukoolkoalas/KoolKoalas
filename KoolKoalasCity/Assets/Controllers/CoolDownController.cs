using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownController : MonoBehaviour
{
    public DateTime currentTime;
    private DateTime nextHeartTime;
    public DateTime NextPopUpTime;


    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now;
        nextHeartTime = currentTime.AddSeconds(30);
        NextPopUpTime = currentTime.AddSeconds(45);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.Now;
        if (currentTime >= nextHeartTime && GlobalData.HeartCounter != 5)
        {
            GlobalData.HeartChange++;
            nextHeartTime = currentTime.AddSeconds(30);
        }
        if (currentTime >= NextPopUpTime)
        {
            print("popup pasikeicia");
            print(GlobalData.PopUpCounter);
            GlobalData.PopUpCounter = 1;
            NextPopUpTime = currentTime.AddSeconds(45);
        }
    }
}
