using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveController : MonoBehaviour
{
    bool inProgress = false;

    public void SaveFile()
    {
        if (inProgress) return;
        Debug.Log("Saving");
        inProgress = true;
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        Save data = new Save();
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Saving Complete");
        inProgress = false;
    }

    public void LoadFile()
    {
        if (inProgress) return;
        Debug.Log("Loading");
        inProgress = true;
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.Log("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        Save data = (Save)bf.Deserialize(file);
        file.Close();

        data.UpdateGame();
        Debug.Log("Loading complete");
        inProgress = false;
    }
    [System.Serializable]
    public class Save
    {
        private int Koins { get; set; }
        private float Progress { get; set; }
        private int Memory { get; set; }
        private DateTime RewardTime { get; set; }
        private int Recycling { get; set; }
        private int Race { get; set; }
        private int Food { get; set; }
        private int Clean { get; set; }
        private int Happy { get; set; }
        private bool[] Bought { get; set; }
        private GameObject[] Shown { get; set; }
        private DateTime LastPlayed { get; set; }
        private DateTime LastCleaned { get; set; }
        private DateTime LastFed { get; set; }
        private bool Tutorial { get; set; }
        public Save()
        {
            Koins = GlobalData.KoinCounter;
            Progress = GlobalData.ProgressBarValue;
            Memory = GlobalData.MemoryGameBeaten;
            RewardTime = GlobalData.NextRewardTime;
            Recycling = GlobalData.RecyclingCompleted;
            Race = GlobalData.RaceCompleted;
            Food = GlobalData.food;
            Clean = GlobalData.clean;
            Happy = GlobalData.happy;
            Bought = GlobalData.BoughtReserve;
            Shown = GlobalData.ShownReserve;
            LastPlayed = GlobalData.lastPlayed;
            LastCleaned = GlobalData.lastCleaned;
            LastFed = GlobalData.lastFed;
            Tutorial = GlobalData.tutorialShown;
        }

        public void UpdateGame()
        {
            GlobalData.KoinCounter = Koins;
            GlobalData.ProgressBarValue = Progress;
            GlobalData.MemoryGameBeaten = Memory;
            GlobalData.NextRewardTime = RewardTime;
            GlobalData.RecyclingCompleted = Recycling;
            GlobalData.RaceCompleted = Race;
            GlobalData.food = Food;
            GlobalData.clean = Clean;
            GlobalData.happy = Happy;
            GlobalData.BoughtReserve = Bought;
            GlobalData.ShownReserve = Shown;
            GlobalData.lastFed = LastFed;
            GlobalData.lastPlayed = LastPlayed;
            GlobalData.lastCleaned = LastCleaned;
            GlobalData.tutorialShown = Tutorial;
        }
    }
}
