using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuildingClicker : MonoBehaviour
{
    private void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        { 
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if (hit.transform.name == "Cube (1)" || hit.transform.name == "Cube")
                {
                    SceneManager.LoadScene("GameScene");
                }
            }          
           

        }
    }
}
