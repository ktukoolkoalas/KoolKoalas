using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReserveController : MonoBehaviour
{
    public int TrashPrice = 10;
    public GameObject trash1;
    public GameObject trash2;
    public GameObject trash3;

    public void CollectTrash1()
    {
        trash1.SetActive(false);
        GlobalData.KoinChange += TrashPrice;
    }

    public void CollectTrash2()
    {
        trash2.SetActive(false);
        GlobalData.KoinChange += TrashPrice;
    }

    public void CollectTrash3()
    {
        trash3.SetActive(false);
        GlobalData.KoinChange += TrashPrice;
    }

    public void GoBackToTown()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GoToPou()
    {
        SceneManager.LoadScene("TakingCareOfKoalas");
    }
    public void GoToReserve()
    {
        SceneManager.LoadScene("ReserveScene");
    }
}
