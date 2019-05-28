using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DailyRewardController : MonoBehaviour
{
    public GameObject RewardTable;
    public Text RewardSizeText;
    DateTime CurrentTime;
    public double NextRewardSeconds = 30.0;
    public GameObject RewardButton;

    private void Start()
    {
        CurrentTime = DateTime.Now;
        if (GlobalData.NextRewardTime == default(DateTime))
            GlobalData.NextRewardTime = CurrentTime.AddSeconds(NextRewardSeconds);
    }

    private void Update()
    {
        CurrentTime = DateTime.Now;
        if (GlobalData.NextRewardTime != default(DateTime) && CurrentTime >= GlobalData.NextRewardTime)
        {
            RewardButton.SetActive(true);
            GlobalData.NextRewardTime = CurrentTime.AddSeconds(NextRewardSeconds);
        }
    }

    public void ShowDailyReward()
    {
        RewardTable.SetActive(true);
        int RewardSize = GenerateRewardSize();
        GlobalData.KoinChange += RewardSize;
        RewardSizeText.text = RewardSize.ToString();
    }

    public void CloseDailyReward()
    {
        RewardTable.SetActive(false);
        RewardButton.SetActive(false);
    }

    public int GenerateRewardSize()
    {
        int reward = UnityEngine.Random.Range(1, 101);
        return reward;
    }


}
