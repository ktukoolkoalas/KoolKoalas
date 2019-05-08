using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestaurantController : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    private int _score = 0;
    [SerializeField] private TextMesh timeLabel;
    private int orderCount;
    private int clickCount = 0;
    private int[] answer;
    private int[] orders;
    public Image order0;
    public Image order1;
    public Image order2;
    public Image order3;
    public Image order4;
    public GameObject correct;
    public GameObject wrong;
    public GameObject orderAlert;
    // Start is called before the first frame update
    void Start()
    {
        timeLabel.text = "Time left: 32";
        StartCoroutine(Counter());
        GetLevel();
        orders = Generate(orderCount);
        ChangeOrderSprites();
        StartCoroutine(ShowOrder());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainScene");
        }
        if (orderAlert.activeInHierarchy == false)
        {
            if (clickCount == orderCount)
            {
                DisableButtons();
                Sort(orders);
                Sort(answer);
                if (IsCorrect())
                {
                    StartCoroutine(ShowCorrect());
                }
                else StartCoroutine(ShowWrong());
                orders = Generate(orderCount);
                ChangeOrderSprites();
                StartCoroutine(ShowOrder());
                clickCount = 0;
            }
        }
    }
    private IEnumerator Counter()
    {
        int currCountdownValue = 32;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            if (currCountdownValue == 0)
            {
                SceneManager.LoadScene("MainScene");
            }
            else timeLabel.text = "Time left: " + currCountdownValue.ToString();
        }
    }
    private void GetLevel()
    {
        switch (GlobalData.MemoryGameLevel)
        {
            case 2:
                orderCount = 4;
                orders = new int[4];
                //currentLevel = 2;
                answer = new int[4];
                break;
            case 3:
                orderCount = 5;
                orders = new int[5];
                //currentLevel = 3;
                answer = new int[5];
                break;
            case 1:
            default:
                orderCount = 3;
                orders = new int[3];
                answer = new int[3];
                break;
        }
    }
    private int[] Generate(int n)
    {
        int[] numbers = new int[n];
        System.Random r = new System.Random();
        for (int i=0; i < n; i++)
        {
            numbers[i] = r.Next(0, 11);
        }
        return numbers;
    }
    private void DisableButtons()
    {

    }
    private void EnableButtons()
    {

    }
    public void Hotdog() { answer[clickCount++] = 0; }
    public void Donut() { answer[clickCount++] = 1; }
    public void Soda() { answer[clickCount++] = 2; }
    public void IceCream() { answer[clickCount++] = 3; }
    public void Cupcake() { answer[clickCount++] = 4; }
    public void Burger() { answer[clickCount++] = 5; }
    public void Coffee() { answer[clickCount++] = 6; }
    public void Fries() { answer[clickCount++] = 7; }
    public void Juice() { answer[clickCount++] = 8; }
    public void Muffin() { answer[clickCount++] = 9; }
    public void Popcorn() { answer[clickCount++] = 10; }
    private int[] Sort(int[] numbers)
    {
        for(int i = 0; i < numbers.Length; i++)
        {
            for(int j = i; j < numbers.Length; j++)
            {
                if(numbers[i] < numbers[j])
                {
                    int tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;
                }
            }
        }
        return numbers;
    }
    private bool IsCorrect()
    {
        for(int i = 0; i < clickCount; i++)
        {
            if (answer[i] != orders[i])
                return false;
        }
        return true;
    }
    private IEnumerator ShowCorrect()
    {
        correct.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        correct.SetActive(false);
    }
    private IEnumerator ShowWrong()
    {
        wrong.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wrong.SetActive(false);
    }
    private IEnumerator ShowOrder()
    {
        orderAlert.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        orderAlert.SetActive(false);
    }
    public void ChangeOrderSprites()
    {
        order0.sprite = images[orders[0]];
        order1.sprite = images[orders[1]];
        order2.sprite = images[orders[2]];
        if(orderCount >= 4)
            order3.sprite = images[orders[3]];
        if(orderCount == 5)
            order4.sprite = images[orders[4]];
    }
}
