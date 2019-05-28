using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

//This is the main script that will run the game.
public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject[] images; 
    public GameObject CityObject;
    public HeartController HeartAlertObject;
    public Text ProgressText;
    public GameObject Welcome;
    public ParticleSystem gas;

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
        DeleteTrash(0.1f, "Trash1");
        DeleteTrash(0.2f, "Trash2");
        DeleteTrash(0.3f, "Trash3");
        DeleteTrash(0.4f, "Trash4");
        DeleteTrash(0.5f, "Trash5");

        if (GlobalData.ProgressBarValue >= 0.5f)
        {
            gas.Pause();
        }

        ProgressText.text = (GlobalData.ProgressBarValue * 10).ToString() + "/100";

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
    public void DeleteTrash(float progressValue, string tagName)
    {
        if (GlobalData.ProgressBarValue >= progressValue)
        {
            for (int i = 0; i < images.Length; i++)
            {
                if (images[i].tag == tagName)
                    images[i].SetActive(false);
            }
        }
    }

    public void CloseWindow()
    {
        Welcome.SetActive(false);
    }

}
