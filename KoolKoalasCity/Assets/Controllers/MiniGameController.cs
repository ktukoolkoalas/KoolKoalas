using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{

    public int CoinReward = GlobalData.RecyclingGameScore;
    public GameObject PopUpButton;

    // Start is called before the first frame update
    void Start()
    {
        ShowPopUpButton();
    }

    // Update is called once per frame
    void Update()
    {
        ShowPopUpButton();
    }


    public void GoToMainScene()
    {
        if(GlobalData.MainScene == null || GlobalData.MainScene == "")
        {
            GlobalData.MainScene = "MainScene";
            //return;
        }
        GlobalData.KoinChange += CoinReward;
        SceneManager.LoadScene(GlobalData.MainScene);
    }

    public void ShowPopUpButton()
    {
        if (GlobalData.PopUpCounter > 0)
        {
            PopUpButton.SetActive(true);
        }
        else
        {
            PopUpButton.SetActive(false);
        }
    }
}
