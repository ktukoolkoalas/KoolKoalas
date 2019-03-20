using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameController : MonoBehaviour
{

    public int CoinReward = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
