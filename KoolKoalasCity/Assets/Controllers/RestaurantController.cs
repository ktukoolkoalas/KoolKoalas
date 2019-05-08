using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestaurantController : MonoBehaviour
{
    [SerializeField] private Sprite[] images;
    private int _score = 0;
    public GameObject timeLabel;
    public Text timeText;
    public GameObject scoreLabel;
    public Text scoreText;
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
    public Button hotdog;
    public Button donut;
    public Button soda;
    public Button icecream;
    public Button cupcake;
    public Button burger;
    public Button coffee;
    public Button fries;
    public Button juice;
    public Button muffin;
    public Button popcorn;
    private int level;
    public GameObject instructions;
    public GameObject timeover;
    public Text totalScore;
    // Start is called before the first frame update
    void Start()
    {
        DisableButtons();
        GetLevel();
        instructions.SetActive(true);
        timeText.text = "32";
        scoreText.text = "0";
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainScene");
        }
        scoreText.text =  _score.ToString();
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
    public void BackToTown()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void PlayGame()
    {
        instructions.SetActive(false);
        timeLabel.SetActive(true);
        scoreLabel.SetActive(true);
        StartCoroutine(Counter());
        EnableButtons();
        orders = Generate(orderCount);
        ChangeOrderSprites();
        StartCoroutine(ShowOrder());
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
                DisableButtons();
                timeover.SetActive(true);
                totalScore.text = _score.ToString();
            }
            else timeText.text = currCountdownValue.ToString();
        }
    }
    private void GetLevel()
    {
        switch (level)
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
        hotdog.interactable = false;
        donut.interactable = false;
        soda.interactable = false;
        icecream.interactable = false;
        cupcake.interactable = false;
        burger.interactable = false;
        coffee.interactable = false;
        fries.interactable = false;
        juice.interactable = false;
        muffin.interactable = false;
        popcorn.interactable = false;
    }
    private void EnableButtons()
    {
        hotdog.interactable = true;
        donut.interactable = true;
        soda.interactable = true;
        icecream.interactable = true;
        cupcake.interactable = true;
        burger.interactable = true;
        coffee.interactable = true;
        fries.interactable = true;
        juice.interactable = true;
        muffin.interactable = true;
        popcorn.interactable = true;
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
        _score++;
        return true;
    }
    private IEnumerator ShowCorrect()
    {
        DisableButtons();
        correct.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        correct.SetActive(false);
    }
    private IEnumerator ShowWrong()
    {
        DisableButtons();
        wrong.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        wrong.SetActive(false);
    }
    private IEnumerator ShowOrder()
    {
        yield return new WaitForSeconds(0.5f);
        orderAlert.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        orderAlert.SetActive(false);
        EnableButtons();
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
