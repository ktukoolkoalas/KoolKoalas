using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartController : MonoBehaviour
{
    public Text heartText;

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
        heartText.text = GlobalData.HeartCounter.ToString();
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

    /*public void ShowAlert()
    {
        gameObject.SetActive(true);
        gameObject.transform.SetAsLastSibling();
        AlertText.text = "You don't have enough lives";
        QuestionShowing = true;
        WaitForSecondsRealtime(10);
        gameObject.SetActive(false);
        QuestionShowing = false;
    }*/

}
