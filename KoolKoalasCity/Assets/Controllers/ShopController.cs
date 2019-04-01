using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject ShopWindow;
    public GameObject FoodStorage;
    public GameObject StuffStorage;
    public int FoodPrice = 5;
    public Text Koins;

    public void ShowShop()
    {
        ShopWindow.SetActive(true);
        ShopWindow.transform.SetAsLastSibling();
        Koins.text = GlobalData.KoinCounter.ToString();
    }

    public void CloseShop()
    {
        ShopWindow.SetActive(false);
        FoodStorage.SetActive(false);
        StuffStorage.SetActive(false);
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
            GlobalData.KoinChange = 5;
            Koins.text = GlobalData.KoinCounter.ToString();
            print(GlobalData.KoinCounter);
        }        
    }

}
