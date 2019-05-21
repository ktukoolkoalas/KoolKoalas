using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarCameraController : MonoBehaviour
{
    [SerializeField] Transform observable;
    [SerializeField] float aheadSpeed;
    [SerializeField] float followDamping;
    [SerializeField] float cameraHeight;

    Rigidbody _observableRigidBody;
    

    [SerializeField] Text PositionText;
    [SerializeField] Text CountDownText;
    [SerializeField] Text LapText;
    [SerializeField] GameObject ScorePanel;

    [SerializeField] int ScaleParts = 50;
    [SerializeField] float SizeMultiplier = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _observableRigidBody = observable.GetComponent<Rigidbody>();
        StartCoroutine(CountDownRace());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainScene");
        }

        if (observable == null) return;


        Vector3 targetPosition = observable.position + Vector3.up * cameraHeight + _observableRigidBody.velocity * aheadSpeed;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followDamping * Time.deltaTime);

        //update canvas
        CarController car = observable.GetComponent<CarController>();
        PositionText.text = car.GetRacePosition() + "/" + observable.parent.childCount;

        LapText.text = car.CurrLap + "/" + car.LapCount;
    }

    IEnumerator CountDownRace()
    {
        //float runtime = 1f;
        for (int i = 3; i > 0; i--)
        {
            CountDownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        CountDownText.text = "";
        Transform Parent = observable.parent;
        for(int j = 0; j < Parent.childCount; j++)
        {
            Parent.GetChild(j).GetComponent<CarController>().MovementEnabled = 1;
        }
    }

    public void ShowScore()
    {
        StartCoroutine(ScoreScreen());
    }

    IEnumerator ScoreScreen()
    {
        ScorePanel.SetActive(true);
        Text text = ScorePanel.transform.GetChild(0).Find("ScorePositionText").GetComponent<Text>();
        int racePosition = observable.GetComponent<CarController>().GetRacePosition();
        string pos = "";
        int koalas = 0;
        switch (racePosition)
        {
            case 1:
                pos = "1st";
                koalas = 3;
                break;
            case 2:
                pos = "2nd";
                koalas = 2;
                break;
            case 3:
                pos = "3rd";
                koalas = 2;
                break;
            default:
                pos = racePosition + "th";
                koalas = 1;
                break;
        }
        text.text = "You came in " + pos + "!";
        yield return new WaitForSeconds(1);
        
        for(int i = 1; i <= koalas; i++)
        {
            Transform koala = ScorePanel.transform.GetChild(0).Find("Koala" + i + "Image");
            koala.gameObject.SetActive(true);
            float lowerX = koala.localScale.x * SizeMultiplier / ScaleParts;
            float lowerY = koala.localScale.y * SizeMultiplier / ScaleParts;
            koala.localScale.Set(koala.localScale.x * (SizeMultiplier + 1), koala.localScale.y * (SizeMultiplier + 1), koala.localScale.z);
            for (int j = 0; j < ScaleParts; j++)
            {
                koala.localScale.Set(koala.localScale.x - lowerX, koala.localScale.y - lowerY, koala.localScale.z);
                yield return null;
            }
        }
        yield return new WaitForSeconds(3);
        if(GlobalData.RaceCompleted < koalas)
        {
            GlobalData.ProgressDone = koalas - GlobalData.RaceCompleted;
            GlobalData.RaceCompleted = koalas;
        }
        SceneManager.LoadScene("MainScene");

    }
}
