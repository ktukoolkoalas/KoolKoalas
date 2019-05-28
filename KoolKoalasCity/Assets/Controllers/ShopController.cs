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

    public void Start()
    {
        for (int i = 0; i < GlobalData.BoughtReserve.Length; i++)
        {
            if (GlobalData.BoughtReserve[i])
            {
                switch (i)
                {
                    case 0:
                        ReFood1.SetActive(true);
                        ShowButton1.transform.SetAsLastSibling();
                        break;
                    case 1:
                        ShowButton2.SetActive(true);
                        ShowButton2.transform.SetAsLastSibling();
                        break;
                    case 2:
                        ShowButton3.SetActive(true);
                        ShowButton3.transform.SetAsLastSibling();
                        break;
                    case 3:
                        ShowButton4.SetActive(true);
                        ShowButton4.transform.SetAsLastSibling();
                        break;
                    case 4:
                        ShowButton5.SetActive(true);
                        ShowButton5.transform.SetAsLastSibling();
                        break;
                    case 5:
                        ShowButton11.SetActive(true);
                        ShowButton11.transform.SetAsLastSibling();
                        break;
                    case 6:
                        ShowButton22.SetActive(true);
                        ShowButton22.transform.SetAsLastSibling();
                        break;
                    case 7:
                        ShowButton33.SetActive(true);
                        ShowButton33.transform.SetAsLastSibling();
                        break;
                    case 8:
                        ShowButton44.SetActive(true);
                        ShowButton44.transform.SetAsLastSibling();
                        break;
                    case 9:
                        ShowButton55.SetActive(true);
                        ShowButton55.transform.SetAsLastSibling();
                        break;
                    case 10:
                        ShowButton66.SetActive(true);
                        ShowButton66.transform.SetAsLastSibling();
                        break;
                    case 11:
                        ShowButton77.SetActive(true);
                        ShowButton77.transform.SetAsLastSibling();
                        break;
                    default:
                        Debug.Log("There are more objects then coded for");
                        break;
                }
            }
            if (GlobalData.ShownReserve[i] != null)
            {
                switch (i)
                {
                    case 0:
                        SetObject(ReFood1, GlobalData.ShownReserve[i]);
                        break;
                    case 1:
                        SetObject(ReFood2, GlobalData.ShownReserve[i]);
                        break;
                    case 2:
                        SetObject(ReFood3, GlobalData.ShownReserve[i]);
                        break;
                    case 3:
                        SetObject(ReFood4, GlobalData.ShownReserve[i]);
                        break;
                    case 4:
                        SetObject(ReFood5, GlobalData.ShownReserve[i]);
                        break;
                    case 5:
                        SetObject(ReStuff1, GlobalData.ShownReserve[i]);
                        break;
                    case 6:
                        SetObject(ReStuff2, GlobalData.ShownReserve[i]);
                        break;
                    case 7:
                        SetObject(ReStuff3, GlobalData.ShownReserve[i]);
                        break;
                    case 8:
                        SetObject(ReStuff4, GlobalData.ShownReserve[i]);
                        break;
                    case 9:
                        SetObject(ReStuff5, GlobalData.ShownReserve[i]);
                        break;
                    case 10:
                        SetObject(ReStuff6, GlobalData.ShownReserve[i]);
                        break;
                    case 11:
                        SetObject(ReStuff7, GlobalData.ShownReserve[i]);
                        break;
                    default:
                        Debug.Log("There are more objects then coded for");
                        break;
                }
            }
        }
    }

    private void SetObject(GameObject target, GameObject source)
    {
        target.SetActive(true);
        target.transform.SetAsLastSibling();
        target.transform.position = source.transform.position;
    }

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
            GlobalData.BoughtReserve[0] = true;

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
        GlobalData.ShownReserve[0] = ReFood1;
    }

    public void BuyFood2()
    {
        if (GlobalData.KoinCounter >= FoodPrice)
        {
            GlobalData.KoinChange -= FoodPrice;
            ShowButton2.SetActive(true);
            ShowButton2.transform.SetAsLastSibling();
            GlobalData.BoughtReserve[1] = true;
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
        GlobalData.ShownReserve[1] = ReFood2;
    }

    public void BuyFood3()
    {
        if (GlobalData.KoinCounter >= FoodPrice)
        {
            GlobalData.KoinChange -= FoodPrice;
            ShowButton3.SetActive(true);
            ShowButton3.transform.SetAsLastSibling();
            GlobalData.BoughtReserve[2] = true;
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
        GlobalData.ShownReserve[2] = ReFood3;
    }

    public void BuyFood4()
    {
        if (GlobalData.KoinCounter >= FoodPrice)
        {
            GlobalData.KoinChange -= FoodPrice;
            ShowButton4.SetActive(true);
            ShowButton4.transform.SetAsLastSibling();
            GlobalData.BoughtReserve[3] = true;
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
        GlobalData.ShownReserve[3] = ReFood4;
    }

    public void BuyFood5()
    {
        if (GlobalData.KoinCounter >= FoodPrice)
        {
            GlobalData.KoinChange -= FoodPrice;
            ShowButton5.SetActive(true);
            ShowButton5.transform.SetAsLastSibling();
            GlobalData.BoughtReserve[4] = true;
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
        GlobalData.ShownReserve[4] = ReFood5;
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
            GlobalData.BoughtReserve[5] = true;
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
        GlobalData.ShownReserve[5] = ReStuff1;
    }

    public void BuyStuff2()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton22.SetActive(true);
            ShowButton22.transform.SetAsLastSibling();
            GlobalData.BoughtReserve[6] = true;
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
        GlobalData.ShownReserve[6] = ReStuff2;
    }

    public void BuyStuff3()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton33.SetActive(true);
            ShowButton33.transform.SetAsLastSibling();
            GlobalData.BoughtReserve[7] = true;
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
        GlobalData.ShownReserve[7] = ReStuff3;
    }

    public void BuyStuff4()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton44.SetActive(true);
            ShowButton44.transform.SetAsLastSibling();
            GlobalData.BoughtReserve[8] = true;
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
        GlobalData.ShownReserve[8] = ReStuff4;
    }

    public void BuyStuff5()
    {
        if (GlobalData.KoinCounter >= StuffPrice)
        {
            GlobalData.KoinChange -= StuffPrice;
            ShowButton55.SetActive(true);
            ShowButton55.transform.SetAsLastSibling();
            GlobalData.BoughtReserve[9] = true;
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
        GlobalData.ShownReserve[9] = ReStuff5;
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
            GlobalData.BoughtReserve[11] = true;
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
        GlobalData.ShownReserve[11] = ReStuff7;
    }
}
