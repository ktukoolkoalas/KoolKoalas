using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayHint : MonoBehaviour
{
    public GameObject hintLogo;

    public void Start()
    {
        hintLogo.SetActive(false);
    }

    public void OnMouseOver()
    {
        hintLogo.SetActive(true);
        hintLogo.transform.SetAsLastSibling();
    }

    public void OnMouseExit()
    {
        hintLogo.SetActive(false);
    }
}
