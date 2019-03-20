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
        if (GlobalData.NextHeartTime == null)
            GlobalData.NextHeartTime = CurrentTime.AddSeconds(NextHeartSeconds);
        if (GlobalData.NextPopUpTime == null)
            GlobalData.NextPopUpTime = CurrentTime.AddSeconds(NextPopupSeconds);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime = DateTime.Now;
        
        if (GlobalData.NextHeartTime != null && CurrentTime >= GlobalData.NextHeartTime)
        {
            GlobalData.HeartChange++; //pakeist i +5
            GlobalData.NextHeartTime = CurrentTime.AddSeconds(NextHeartSeconds);
        }
        if (GlobalData.NextPopUpTime != null && CurrentTime >= GlobalData.NextPopUpTime)
        {
            GlobalData.PopUpCounter++; //pakeist i 5
            GlobalData.NextPopUpTime = CurrentTime.AddSeconds(NextPopupSeconds);
        }
    }
}
