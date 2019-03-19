using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BackgroundController : MonoBehaviour
{
    public DateTime currentTime;
    private DateTime nextDayBackgroundActivatedTime;
    private DateTime nextDayBackgroundUnactivatedTime;

    public GameObject DayBackground;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now;
        nextDayBackgroundActivatedTime = currentTime.AddSeconds(10);
        nextDayBackgroundUnactivatedTime = currentTime.AddSeconds(20);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.Now;
        if (currentTime >= nextDayBackgroundActivatedTime)
        {
            DayBackground.SetActive(true);
        }
        if (currentTime >= nextDayBackgroundUnactivatedTime)
        {
            DayBackground.SetActive(false);
        }

    }

    //public DateTime currentTime;
    //public DateTime unactivatedTimeCounter;

    //public GameObject DayBackground;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    currentTime = DateTime.Now;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    bool activated = false;
    //    for (int i = 0; i < 1440; i = i + 10)
    //    {
    //        activatedTimeCounter += DateTime.Now.AddMinutes(i);
    //        print(activatedTimeCounter);
    //    }

    //    unactivatedTimeCounter += 20;
    //    for (int i = currentTime.AddSeconds(10); i < currentTime.AddMinutes(1); i = currentTime.AddSeconds(activatedTimeCounter))
    //    {
    //        if (activated == false)
    //        {
    //            DayBackground.SetActive(true);
    //            activated = false;                                             
    //        }
    //        for (int j = currentTime.AddSeconds(20); j < currentTime.AddMinutes(1); i = currentTime.AddSeconds(unactivatedTimeCounter))
    //        {
    //            if (activated == true)
    //            {
    //                DayBackground.SetActive(false);
    //                activated = true;
    //            }
    //        }
    //    }
    //}
}
