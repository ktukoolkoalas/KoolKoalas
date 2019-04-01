using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReserveController : MonoBehaviour
{
    public void GoBackToTown()
    {
        SceneManager.LoadScene("MainScene");
    }
}
