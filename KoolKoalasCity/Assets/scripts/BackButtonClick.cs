using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButtonClick : MonoBehaviour
{
    // Start is called before the first frame update
    public void ClickTheButton(string scenename)
    {
        Application.LoadLevel(scenename);
    }
}
