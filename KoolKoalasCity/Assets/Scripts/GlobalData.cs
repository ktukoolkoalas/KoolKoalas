using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalData
{
    public static string MainScene = "";
    public static bool NeedToUpdateProgress = false;
    public static int KoinChange = 0;
    public static int KoinCounter = 0; //used only by KoinController
    public static int PopUpCounter = 2;
    public static int HeartCounter = 5;
    public static int HeartChange = 0;

    public static float ProgressBarValue = 0;

    public static bool TrashGameDropping = false;
    public static int MemoryGameLevel = 1;
    public static int MemoryGameBeaten = 0;

    public static DateTime NextHeartTime;
    public static DateTime NextPopUpTime;

}
