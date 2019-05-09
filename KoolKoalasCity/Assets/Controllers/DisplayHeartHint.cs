using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHeartHint : MonoBehaviour
{
    public GameObject logoText;

    public void Start()
    {
        logoText.SetActive(false);
    }

    public void OnMouseOver()
    {
        logoText.SetActive(true);
    }

    public void OnMouseExit()
    {
        logoText.SetActive(false);
    }
}
