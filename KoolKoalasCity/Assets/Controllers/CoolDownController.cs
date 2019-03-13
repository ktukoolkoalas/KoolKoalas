using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolDownController : MonoBehaviour
{
    public DateTime currentTime;
    private DateTime nextHeartTime;
    
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = DateTime.Now;
        nextHeartTime = currentTime.AddSeconds(30);
        print("start");
        print(currentTime);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = DateTime.Now;
        if (currentTime >= nextHeartTime && GlobalData.HeartCounter != 5)
        {
            GlobalData.HeartChange++;
            print("update");
            nextHeartTime = currentTime.AddSeconds(30);
        }

    }
}
