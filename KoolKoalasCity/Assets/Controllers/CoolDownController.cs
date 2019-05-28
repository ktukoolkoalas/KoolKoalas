using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownController : MonoBehaviour
{
    private DateTime CurrentTime;

    public double NextHeartSeconds = 30.0;
    public double NextPopupSeconds = 45.0;


    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = DateTime.Now;
        if (GlobalData.NextHeartTime == default(DateTime))
            GlobalData.NextHeartTime = CurrentTime.AddSeconds(NextHeartSeconds);
        if (GlobalData.NextPopUpTime == default(DateTime))
            GlobalData.NextPopUpTime = CurrentTime.AddSeconds(NextPopupSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime = DateTime.Now;
        
        if (GlobalData.NextHeartTime != default(DateTime) && CurrentTime >= GlobalData.NextHeartTime)
        {
            GlobalData.HeartChange++; //pakeist i +5
            GlobalData.NextHeartTime = CurrentTime.AddSeconds(NextHeartSeconds);
        }
        if (GlobalData.NextPopUpTime != default(DateTime) && CurrentTime >= GlobalData.NextPopUpTime)
        {
            GlobalData.PopUpCounter++; //pakeist i 5
            GlobalData.NextPopUpTime = CurrentTime.AddSeconds(NextPopupSeconds);
        }
    }
}
