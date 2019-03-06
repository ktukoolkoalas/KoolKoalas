using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoalaKoins : MonoBehaviour
{

    public Text koinText;
    private long koinCounter;

    // Start is called before the first frame update
    void Start()
    {
        koinCounter = 1000000000;

    }

    // Update is called once per frame
    void Update()
    {
        koinText.text = ShortenKoinCounter();
    }

    long AddKoin (int koinsToAdd)
    {
        koinCounter += koinsToAdd;

        return koinCounter;
    }

    bool SubtractKoin(int koinsToSubtract)
    {
        if (koinsToSubtract <= koinCounter)
        {
            koinCounter -= koinsToSubtract;

            return true;
        }

        return false;
    }

    string ShortenKoinCounter()
    {
        string koinAmount;

        if (koinCounter >= 1000000000)
            koinAmount = (koinCounter / 1000000000).ToString() + "MM";
        else if (koinCounter >= 10000000)
            koinAmount = (koinCounter / 1000000).ToString() + "M";
        else if (koinCounter >= 10000)
            koinAmount = (koinCounter / 1000).ToString() + "K";
        else
            koinAmount = koinCounter.ToString();

        return koinAmount;
    }
}
