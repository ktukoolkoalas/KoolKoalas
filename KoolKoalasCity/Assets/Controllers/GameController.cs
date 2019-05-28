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

    SaveController saving;
    float nextSaveTime = 0.0f;
    float savePeriod = 30f;

    // Use this for initialization
    void Start()
    {
        saving = transform.GetComponent<SaveController>();
        saving.LoadFile();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSaveTime)
        {
            nextSaveTime += savePeriod;
            saving.SaveFile();
        }

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
                        if(hit.transform.name == "RestaurantGameCube")
                        {
                            SceneManager.LoadScene("RestaurantScene");
                        }

                        else if (hit.transform.name == "RecyclingGameCube")
                        {
                            SceneManager.LoadScene("RecyclingGame");
                        }

                        else if (hit.transform.name == "CarGameCube")
                        {
                            SceneManager.LoadScene("CarGame");
                        }  

                        /*else
                        {
                            SceneManager.LoadScene("GameScene");
                        }*/

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
