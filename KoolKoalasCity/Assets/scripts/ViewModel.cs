using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ViewModel : MonoBehaviour
{
    public Slider slider;

    public void Button_Click()
    {
        StartCoroutine(FillBar());
    }
    IEnumerator FillBar()
    {
        float runtime = 1f;
        for (int i = 0; i < 25; i++)
        {
            slider.value += (float)0.01;
            yield return null;
        }
    }
}
