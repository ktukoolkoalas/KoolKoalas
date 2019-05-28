using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BackgroundController : MonoBehaviour
{
    public DateTime currentTime;
    private DateTime DayCycleTime;

    public int DayCycle = 10;
    public bool IsDay = true;
    
    public Sprite DayBackground;
    public Sprite NightBackground;
    public Text koins;
    public Text progress;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now;
        DayCycleTime = currentTime.AddSeconds(DayCycle);
        this.GetComponent<SpriteRenderer>().sprite = DayBackground;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.Now;
        if (currentTime >= DayCycleTime)
        {
            if (IsDay)
            {
                this.GetComponent<SpriteRenderer>().sprite = NightBackground;
                koins.color = new Color(255, 255, 255);
                progress.color = new Color(255, 255, 255);
                //lives.color = new Color(255, 255, 255);
                IsDay = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().sprite = DayBackground;
                koins.color = new Color(0, 0, 0);
                //lives.color = new Color(0, 0, 0);
                progress.color = new Color(0, 0, 0);
                IsDay = true;
            }
            
            DayCycleTime = currentTime.AddSeconds(DayCycle);
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
