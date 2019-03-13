using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    public Text HeartText;
    public GameObject HeartAlert;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalData.HeartChange > 0)
        {
            GlobalData.HeartChange--;
            AddHeart(1);
        }
        else if (GlobalData.HeartChange < 0)
        {
            GlobalData.HeartChange++;
            SubtractHeart(1);
        }
        HeartText.text = GlobalData.HeartCounter.ToString();
    }

    bool AddHeart(int heartsToAdd)
    {
        if (GlobalData.HeartCounter >= 5)
        {
            return false;
        }
        else
        {
            GlobalData.HeartCounter += heartsToAdd;
            return true;
        }
        
    }

    bool SubtractHeart(int heartsToSubtract)
    {
        if (GlobalData.HeartCounter <= 0)
        {
            return false;
        }
        GlobalData.HeartCounter -= heartsToSubtract;
        return true;

    }

    public void ShowAlert()
    {
        HeartAlert.SetActive(true);
        HeartAlert.transform.SetAsLastSibling(); //paskutini uzkrauna
    }

    public void CloseAlert()
    {
        HeartAlert.SetActive(false);
    }

}
