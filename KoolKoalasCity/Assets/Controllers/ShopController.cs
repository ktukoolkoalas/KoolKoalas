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

    public GameObject ShowButton1;
    public GameObject ReFood1;

    public GameObject ShowButton2;
    public GameObject ReFood2;

    public GameObject ShowButton3;
    public GameObject ReFood3;

    public GameObject ShowButton4;
    public GameObject ReFood4;

    public GameObject ShowButton5;
    public GameObject ReFood5;


    public GameObject ShowButton11;
    public GameObject ReStuff1;

    public GameObject ShowButton22;
    public GameObject ReStuff2;

    public GameObject ShowButton33;
    public GameObject ReStuff3;

    public GameObject ShowButton44;
    public GameObject ReStuff4;

    public GameObject ShowButton55;
    public GameObject ReStuff5;

    public GameObject ShowButton66;
    public GameObject ReStuff6;

    public GameObject ShowButton77;
    public GameObject ReStuff7;

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

    //public void BuyFood()
    //{
    //    if (GlobalData.KoinCounter >= FoodPrice)
    //    {
    //        GlobalData.KoinChange -= FoodPrice;
    //    }
    //    else
    //    {
    //        NoMoneyAlert.SetActive(true);
    //        NoMoneyAlert.transform.SetAsLastSibling();
    //    }
    //}

    public void BuyFood1()
    {
        if (GlobalData.KoinCounter >= FoodPrice)
        {
            GlobalData.KoinChange -= FoodPrice;
            ShowButton1.SetActive(true);
            ShowButton1.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowFood1()
    {
        CloseShop();
        ReFood1.SetActive(true);
        ReFood1.transform.SetAsLastSibling();
    }

    public void BuyFood2()
    {
        if (GlobalData.KoinCounter >= FoodPrice)
        {
            GlobalData.KoinChange -= FoodPrice;
            ShowButton2.SetActive(true);
            ShowButton2.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowFood2()
    {
        CloseShop();
        ReFood2.SetActive(true);
        ReFood2.transform.SetAsLastSibling();
    }

    public void BuyFood3()
    {
        if (GlobalData.KoinCounter >= FoodPrice)
        {
            GlobalData.KoinChange -= FoodPrice;
            ShowButton3.SetActive(true);
            ShowButton3.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowFood3()
    {
        CloseShop();
        ReFood3.SetActive(true);
        ReFood3.transform.SetAsLastSibling();
    }

    public void BuyFood4()
    {
        if (GlobalData.KoinCounter >= FoodPrice)
        {
            GlobalData.KoinChange -= FoodPrice;
            ShowButton4.SetActive(true);
            ShowButton4.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowFood4()
    {
        CloseShop();
        ReFood4.SetActive(true);
        ReFood4.transform.SetAsLastSibling();
    }

    public void BuyFood5()
    {
        if (GlobalData.KoinCounter >= FoodPrice)
        {
            GlobalData.KoinChange -= FoodPrice;
            ShowButton5.SetActive(true);
            ShowButton5.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowFood5()
    {
        CloseShop();
        ReFood5.SetActive(true);
        ReFood5.transform.SetAsLastSibling();
    }

    //public void BuyStuff()
    //{
    //    if (GlobalData.KoinCounter >= StuffPrice)
    //    {
    //        GlobalData.KoinChange -= StuffPrice;
    //    }
    //    else
    //    {
    //        NoMoneyAlert.SetActive(true);
    //        NoMoneyAlert.transform.SetAsLastSibling();
    //    }
    //}

    public void BuyStuff1()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton11.SetActive(true);
            ShowButton11.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowStuff1()
    {
        CloseShop();
        ReStuff1.SetActive(true);
        ReStuff1.transform.SetAsLastSibling();
    }

    public void BuyStuff2()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton22.SetActive(true);
            ShowButton22.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowStuff2()
    {
        CloseShop();
        ReStuff2.SetActive(true);
        ReStuff2.transform.SetAsLastSibling();
    }

    public void BuyStuff3()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton33.SetActive(true);
            ShowButton33.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowStuff3()
    {
        CloseShop();
        ReStuff3.SetActive(true);
        ReStuff3.transform.SetAsLastSibling();
    }

    public void BuyStuff4()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton44.SetActive(true);
            ShowButton44.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowStuff4()
    {
        CloseShop();
        ReStuff4.SetActive(true);
        ReStuff4.transform.SetAsLastSibling();
    }

    public void BuyStuff5()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton55.SetActive(true);
            ShowButton55.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowStuff5()
    {
        CloseShop();
        ReStuff5.SetActive(true);
        ReStuff5.transform.SetAsLastSibling();
    }

    public void BuyStuff6()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton66.SetActive(true);
            ShowButton66.transform.SetAsLastSibling();
            GlobalData.BoughtReserve[10] = true;
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowStuff6()
    {
        CloseShop();
        ReStuff6.SetActive(true);
        ReStuff6.transform.SetAsLastSibling();
        GlobalData.ShownReserve[10] = ReStuff6;
    }

    public void BuyStuff7()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton77.SetActive(true);
            ShowButton77.transform.SetAsLastSibling();
        }
        else
        {
            NoMoneyAlert.SetActive(true);
            NoMoneyAlert.transform.SetAsLastSibling();
        }
    }

    public void ShowStuff7()
    {
        CloseShop();
        ReStuff7.SetActive(true);
        ReStuff7.transform.SetAsLastSibling();
    }
}
