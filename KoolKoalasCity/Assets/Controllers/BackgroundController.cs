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
}
