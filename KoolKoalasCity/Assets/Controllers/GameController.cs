using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

//This is the main script that will run the game.
public class GameController : MonoBehaviour
{

    public GameObject CityObject;
    public GameObject HeartAlertObject;

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
                if (hit.transform.name == "GameLinkCube" || hit.transform.name == "GameLinkCube (1)")
                {
                    if (GlobalData.HeartCounter > 0)
                    {
                        SceneManager.LoadScene("GameScene");
                        Console.WriteLine("kazkas gaunasi");
                        GlobalData.HeartChange--;
                    }
                    else
                    {                        
                        Console.WriteLine("kazkas gaunasi");
                        HeartAlertObject.GetComponent<HeartController>().CloseAlert();
                    }
                }
            }


        }
    }
}
