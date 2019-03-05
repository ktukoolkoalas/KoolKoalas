using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoalaKoins : MonoBehaviour
{

    public Text koinText;
    private int koinCounter;

    // Start is called before the first frame update
    void Start()
    {
        koinCounter = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        subtractKoin(50);
  
        koinText.text = koinCounter.ToString();
        
    }

    int addKoin (int koinsToAdd)
    {
        koinCounter += koinsToAdd;

        return koinCounter;
    }

    bool subtractKoin(int koinsToSubtract)
    {
        if (koinsToSubtract <= koinCounter)
        {
            koinCounter -= koinsToSubtract;

            return true;
        }

        return false;
    }
}
