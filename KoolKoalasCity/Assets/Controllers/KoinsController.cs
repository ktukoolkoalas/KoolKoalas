using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoinsController : MonoBehaviour
{

    public Text koinText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.KoinChange > 0)
        {
            GlobalData.KoinChange--;
            AddKoin(1);
        }
        else if(GlobalData.KoinChange < 0)
        {
            GlobalData.KoinChange++;
            SubtractKoin(1);
        }
        koinText.text = ShortenKoinCounter();
    }

    long AddKoin (int koinsToAdd)
    {
        GlobalData.KoinCounter += koinsToAdd;

        return GlobalData.KoinCounter;
    }

    bool SubtractKoin(int koinsToSubtract)
    {
        if (koinsToSubtract <= GlobalData.KoinCounter)
        {
            GlobalData.KoinCounter -= koinsToSubtract;

            return true;
        }

        return false;
    }

    string ShortenKoinCounter()
    {
        string koinAmount;

        if (GlobalData.KoinCounter >= 1000000000)
            koinAmount = (GlobalData.KoinCounter / 1000000000).ToString() + "MM";
        else if (GlobalData.KoinCounter >= 10000000)
            koinAmount = (GlobalData.KoinCounter / 1000000).ToString() + "M";
        else if (GlobalData.KoinCounter >= 10000)
            koinAmount = (GlobalData.KoinCounter / 1000).ToString() + "K";
        else
            koinAmount = GlobalData.KoinCounter.ToString();

        return koinAmount;
    }
}
