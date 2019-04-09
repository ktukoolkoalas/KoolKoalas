using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KoalaCareController : MonoBehaviour
{
    private int _food;
    private int _happiness;

    public Slider foodSlider;
    public Slider happinessSlider;

    private bool _serverTime;

    public ParticleSystem hearts;
    public GameObject sad;
    public GameObject happy;

    public GameObject foodAlert;
    public GameObject playAlert;

    // Start is called before the first frame update
    void Start()
    {
        happy.SetActive(false);
        sad.SetActive(false);
        foodAlert.SetActive(false);
        playAlert.SetActive(false);
        //updateStatus();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_food < 50 || _happiness < 50)
        {
            sad.SetActive(true);
            happy.SetActive(false);
        }
        else
        {
            sad.SetActive(false);
            happy.SetActive(true);
        }

    }

    void updateStatus()
    {
        if (!PlayerPrefs.HasKey("_food"))
        {
            _food = 100;
            PlayerPrefs.SetInt("_food", _food);
        }
        else
        {
            _food = PlayerPrefs.GetInt("_food");
        }

        if (!PlayerPrefs.HasKey("_happiness"))
        {
            _happiness = 100;
            PlayerPrefs.SetInt("_happiness", _happiness);
        }
        else
        {
            _food = PlayerPrefs.GetInt("_happiness");
        }
    }
    public void Feed()
    {
        if (_food < 100)
        {
            if (_food <= 80)
            {
                _food += 20;
            }
            else _food = 100;
            StartCoroutine(FillBar(foodSlider, 20));
            StartCoroutine(EmitHearts());
        }
        else foodAlert.SetActive(true);
    }
    public void Play()
    {
        if (_happiness < 100)
        {
            if (_happiness <= 80)
            {
                _happiness += 20;
            }
            else _happiness = 100;
            StartCoroutine(FillBar(happinessSlider, 20));
            StartCoroutine(EmitHearts());
        }
        else playAlert.SetActive(true);

    }
    IEnumerator FillBar(Slider slider, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            slider.value += 0.01f;
            yield return null;
        }
    }
    IEnumerator EmitHearts()
    {
        hearts.Play();
        yield return null;
    }
    public void CloseAlert()
    {
        foodAlert.SetActive(false);
        playAlert.SetActive(false);
    }
}
