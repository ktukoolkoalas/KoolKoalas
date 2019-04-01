using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public GameObject ShopWindow;
    public GameObject FoodStorage;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    public void ShowFoodStorage()
    {
        FoodStorage.SetActive(true);
        FoodStorage.transform.SetAsLastSibling();
    }

}
