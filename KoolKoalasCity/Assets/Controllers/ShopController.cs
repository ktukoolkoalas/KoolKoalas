using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject ShopWindow;
    public GameObject FoodStorage;
    public GameObject StuffStorage;
    public GameObject NoMoneyAlert;
    public int FoodPrice = 5;
    public int StuffPrice = 15;

    public void ShowShop()
    {
        ShopWindow.SetActive(true);
        ShopWindow.transform.SetAsLastSibling();
    }

    public void CloseShop()
    {
        ShopWindow.SetActive(false);
        FoodStorage.SetActive(false);
        StuffStorage.SetActive(false);
        NoMoneyAlert.SetActive(false);

    }
    public void CloseAlert()
    {
        NoMoneyAlert.SetActive(false);
    }

    public void ShowFoodStorage()
    {
        FoodStorage.SetActive(true);
        FoodStorage.transform.SetAsLastSibling();
    }

    public void ShowStuffStorage()
    {
        StuffStorage.SetActive(true);
        StuffStorage.transform.SetAsLastSibling();
    }

    public void BuyFood()
    {
        if (GlobalData.KoinCounter >= FoodPrice)
        {
            GlobalData.KoinChange -= FoodPrice;
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void BuyStuff()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }
}
