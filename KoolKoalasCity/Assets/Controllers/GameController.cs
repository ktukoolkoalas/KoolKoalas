using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//This is the main script that will run the game.
public class GameController : MonoBehaviour
{

    public GameObject CityObject;
    public HeartController HeartAlertObject;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.tag == "GameLinkHouse")
                {
                    if (GlobalData.HeartCounter > 0)
                    {
                        if(hit.transform.name == "MemoryGameCube")
                        {
                            Debug.Log("Going to Memory Game");
                            SceneManager.LoadScene("MemoryGame");
                        }
                        else if (hit.transform.name == "TestCube")
                        {
                            
                        }
                        else if (hit.transform.name == "RecycleGameCube")
                        {
                            SceneManager.LoadScene("RecyclingGame");
                        }
                        else
                        {
                            SceneManager.LoadScene("GameScene");
                        }
                        GlobalData.HeartChange--;
                    }
                    else
                    {                        
                        HeartAlertObject.ShowAlert();
                    }
                }
            }
        }
    }


}
