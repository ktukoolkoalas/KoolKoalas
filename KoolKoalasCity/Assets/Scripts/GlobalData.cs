using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static string MainScene = "";
    //public static bool NeedToUpdateProgress = false;
    public static int KoinChange = 0;
    public static int KoinCounter = 30; //used only by KoinController
    public static int PopUpCounter = 2;
    public static int HeartCounter = 5;
    public static int HeartChange = 0;

    public static float ProgressBarValue = 0;
    public static int ProgressDone = 0;

    public static bool TrashGameDropping = false;
    public static int MemoryGameLevel = 1;
    public static int MemoryGameBeaten = 0;
    public static int restaurantNeededScore = 2;

    public static DateTime NextHeartTime;
    public static DateTime NextPopUpTime;
    public static DateTime NextRewardTime;

    public static int RecyclingGameScore = 0;
    public static int RecyclingGameLifeCount = 3;
    public static int RecyclingCompleted = 0;

    public static int food = 50;
    public static int clean = 50;
    public static int happy = 50;

    public static DateTime lastFed = new DateTime();
    public static DateTime lastCleaned = new DateTime();
    public static DateTime lastPlayed = new DateTime();

    public static int RaceCompleted = 0;

    public static bool[] BoughtReserve = new bool[12];
    public static GameObject[] ShownReserve = new GameObject[12];
}
