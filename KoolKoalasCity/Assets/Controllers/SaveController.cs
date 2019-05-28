using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveController : MonoBehaviour
{

    public void SaveFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenWrite(destination);
        else file = File.Create(destination);

        Save data = new Save();
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadFile()
    {
        string destination = Application.persistentDataPath + "/save.dat";
        FileStream file;

        if (File.Exists(destination)) file = File.OpenRead(destination);
        else
        {
            Debug.LogError("File not found");
            return;
        }

        BinaryFormatter bf = new BinaryFormatter();
        Save data = (Save)bf.Deserialize(file);
        file.Close();

        data.UpdateGame();
    }

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
        public Save()
        {
            
        }

        public void UpdateGame()
        {

        }
    }
}
