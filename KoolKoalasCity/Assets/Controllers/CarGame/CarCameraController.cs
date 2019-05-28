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
    [SerializeField] GameObject InstructionPanel;

    [SerializeField] int ScaleParts = 50;
    [SerializeField] float SizeMultiplier = 0.5f;

    [SerializeField] Image Star1;
    [SerializeField] Image Star2;
    [SerializeField] Image Star3;
    [SerializeField] Sprite StarOff;
    [SerializeField] Sprite StarOn;

    // Start is called before the first frame update
    void Start()
    {
        _observableRigidBody = observable.GetComponent<Rigidbody>();

        Star1.sprite = StarOff;
        Star2.sprite = StarOff;
        Star3.sprite = StarOff;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            GoBack();
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
        ScoreScreen();
    }

    public void ScoreScreen()
    {
        ScorePanel.SetActive(true);
        Text text = ScorePanel.transform.Find("MiddleText").GetChild(0).GetComponent<Text>();
        int racePosition = observable.GetComponent<CarController>().GetRacePosition();
        string pos = "";
        int koalas = 0;
        switch (racePosition)
        {
            case 1:
                pos = "1st";
                koalas = 3;
                Star1.sprite = StarOn;
                Star2.sprite = StarOn;
                Star3.sprite = StarOn;
                break;
            case 2:
                pos = "2nd";
                koalas = 2;
                Star1.sprite = StarOn;
                Star2.sprite = StarOn;
                break;
            case 3:
                pos = "3rd";
                koalas = 2;
                Star1.sprite = StarOn;
                Star2.sprite = StarOn;
                break;
            default:
                pos = racePosition + "th";
                koalas = 1;
                Star1.sprite = StarOn;
                break;
        }
        text.text = pos ;
        
        if(GlobalData.RaceCompleted < koalas)
        {
            GlobalData.ProgressDone = koalas - GlobalData.RaceCompleted;
            GlobalData.RaceCompleted = koalas;
        }

    }

    public void ClickInstructionsCloseButton()
    {
        InstructionPanel.SetActive(false);

        StartCoroutine(CountDownRace());
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainScene");
    }
}
