using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TrashController : MonoBehaviour
{
    public int verticalSpeed = 5;
    public int horizontalSpeed = 5;
    public Sprite plastic;
    public Sprite glass;
    public Sprite paper;
    public GameObject PaperObject;
    public GameObject PlasticObject;
    public GameObject GlassObject;
    private GameObject[] TrashObjects = new GameObject[3];
    public GameObject gameover;
    public GameObject instructions;
    public Text totalScore;
    public Text coins;
    public Sprite coloredStar;
    public Image star1;
    public Image star2;
    public Image star3;

    // Start is called before the first frame update
    void Start()
    {
        PlasticObject.GetComponent<SpriteRenderer>().sprite = plastic;
        GlassObject.GetComponent<SpriteRenderer>().sprite = glass;
        PaperObject.GetComponent<SpriteRenderer>().sprite = paper;
        TrashObjects[0] = PaperObject;
        TrashObjects[1] = PlasticObject;
        TrashObjects[2] = GlassObject;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GlobalData.TrashGameDropping && TrashObjects[0] != null && TrashObjects[1] != null && TrashObjects[2] != null)
        {
            GlobalData.TrashGameDropping = true;
            TrashObjects[Random.Range(0, 3)].GetComponent<FallingTrashScript>().Drop(verticalSpeed, horizontalSpeed);
        }
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainScene");
        }
        if(GlobalData.RecyclingGameLifeCount <= 0)
        {
            Time.timeScale = 0;
            gameover.SetActive(true);
            totalScore.text = GlobalData.RecyclingGameScore.ToString();
            coins.text = GlobalData.RecyclingGameScore.ToString();
            GlobalData.TrashGameDropping = false;
            if(GlobalData.RecyclingGameScore <= 5)
            {
                star1.sprite = coloredStar;
            }
            if(GlobalData.RecyclingGameScore <= 10 && GlobalData.RecyclingGameScore > 5)
            {
                star1.sprite = coloredStar;
                star2.sprite = coloredStar;
            }
            if (GlobalData.RecyclingGameScore > 10)
            {
                star1.sprite = coloredStar;
                star2.sprite = coloredStar;
                star3.sprite = coloredStar;
            }
        }
    }
    public void BackToTown()
    {
        SceneManager.LoadScene("MainScene");
        GlobalData.KoinChange += GlobalData.RecyclingGameScore;
        if (GlobalData.RecyclingGameScore >= GlobalData.restaurantNeededScore)
        {
            GlobalData.ProgressDone += 1;
        }
    }
    public void PlayGame ()
    {
        instructions.SetActive(false);
        GlobalData.TrashGameDropping = true;
        Time.timeScale = 1;
    }
}