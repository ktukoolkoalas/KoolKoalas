using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownController : MonoBehaviour
{
    public DateTime CurrentTime;
    private DateTime NextHeartTime;
    public DateTime NextPopUpTime;


    // Start is called before the first frame update
    void Start()
    {
        CurrentTime = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime = DateTime.Now;
        if (NextHeartTime == null)
            NextHeartTime = CurrentTime.AddSeconds(30);
        if (NextPopUpTime == null)
            NextPopUpTime = CurrentTime.AddSeconds(45);
        if (CurrentTime >= NextHeartTime && NextHeartTime != null)
        {
            //GlobalData.HeartChange++; //pakeist i +5
            NextHeartTime = CurrentTime.AddSeconds(30);
        }
        if (CurrentTime >= NextPopUpTime && NextPopUpTime != null)
        {
            //GlobalData.PopUpCounter++; //pakeist i 5
            NextPopUpTime = CurrentTime.AddSeconds(45);
        }
    }
}
