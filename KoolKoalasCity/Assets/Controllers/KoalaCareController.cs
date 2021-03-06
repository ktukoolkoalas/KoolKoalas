﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;
using System;

public class KoalaCareController : MonoBehaviour
{
    //private int _food;
    //private int _happiness;
    //private int _clean;
    public GameObject firstLoginAlert;
    public Slider foodSlider;
    public Slider happinessSlider;
    public Slider hygieneSlider;
    public Text min;
    public Text sec;
    public AudioSource foodSound;
    public AudioSource cleanSound;
    public AudioSource playSound;
    public AudioSource happyKoala;
    public AudioSource sadKoala;
    private int secs = 0;
    private bool _serverTime;
    private bool action = false;
    public ParticleSystem hearts;
    public ParticleSystem food;
    public ParticleSystem bubbles;
    public GameObject sad;
    public GameObject happy;
    public GameObject regeyes;
    public GameObject happyeyes;

    public GameObject foodAlert;
    public GameObject playAlert;
    public GameObject cleanAlert;
    public GameObject coinsAlert;
    public Text coins;
    public Button foodButton;
    public Button playButton;
    public Button cleanButton;
    private bool firstUpdate = true;
    private float period = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        if(GlobalData.lastCleaned == new DateTime())
        {
            firstLoginAlert.SetActive(true);
            GlobalData.lastCleaned = DateTime.Now;
            GlobalData.lastFed = DateTime.Now;
            GlobalData.lastPlayed = DateTime.Now;
        }
        if (GlobalData.food < 21 || GlobalData.happy < 21 || GlobalData.clean < 21)
            StartCoroutine(FadeIn(sadKoala, 0.5f));
        else StartCoroutine(FadeIn(happyKoala, 0.5f));
        happy.SetActive(false);
        sad.SetActive(false);
        foodAlert.SetActive(false);
        playAlert.SetActive(false);
        foodSlider.interactable = false;
        happinessSlider.interactable = false;
        updateStatus();
        //  coinsAlert.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        List<int> values = new List<int>();
        values.Add(GlobalData.food);
        values.Add(GlobalData.happy);
        values.Add(GlobalData.clean);
        int lowest = values[0];
        for (int i = 0; i < 2; i++)
        {
            if (values[i] <= lowest)
            {
                lowest = values[i];
            }
        }

        if((((lowest - 21) * 3) / 60) < 10)
             min.text = "0" + (((lowest - 21) * 3) / 60).ToString();
        else min.text = (((lowest - 21) * 3) / 60).ToString();
        if((((lowest - 21) * 3) % 60) < 10)
            sec.text = "0" + (((lowest - 21) * 3) % 60).ToString();
        else sec.text = (((lowest - 21) * 3) % 60).ToString();

        if ((GlobalData.food < 21 || GlobalData.happy < 21 || GlobalData.clean < 21) && !action)
        {
            sad.SetActive(true);
            happy.SetActive(false);
            
        }
        else
        {
            sad.SetActive(false);
            happy.SetActive(true);
        }
        //--------------------------------------------------

        if (Input.GetMouseButtonDown(0))
        {
            objectToDrag = GetDraggableTransformUnderMouse();

            if (objectToDrag != null)
            {
                dragging = true;

                objectToDrag.SetAsLastSibling();

                originalPosition = objectToDrag.position;
                objectToDragImage = objectToDrag.GetComponent<Image>();
                objectToDragImage.raycastTarget = false;
            }
        }

        if (dragging)
        {
            objectToDrag.position = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (objectToDrag != null)
            {
                var objectToDrop = GetDraggableTransformUnderMouse2();
                if (objectToDrop != null)
                {
                    if (objectToDrag.name == "feed")
                    {
                        Feed();
                    }
                    if (objectToDrag.name == "play")
                    {
                        Play();
                    }
                    if (objectToDrag.name == "clean")
                    {
                        Clean();
                    }
                }
                objectToDrag.position = originalPosition;
                objectToDragImage.raycastTarget = true;
                objectToDrag = null;
            }

            dragging = false;
        }
        if (period > 1.1f)
        {
            period = 0;
            if(GlobalData.food < 21 || GlobalData.happy < 21 || GlobalData.clean < 21)
            {
                if (happyKoala.isPlaying)
                {
                    StartCoroutine(FadeOut(happyKoala, 0.5f));
                    StartCoroutine(FadeIn(sadKoala, 0.5f));
                }

            }
            else
            {
                if (sadKoala.isPlaying)
                {
                    StartCoroutine(FadeOut(sadKoala, 0.5f));
                    StartCoroutine(FadeIn(happyKoala, 0.5f));
                }
            }
            secs++;
            if (secs >= 3)
            {
                updateStatus();
                secs = 0;
            }

        }
        period += UnityEngine.Time.deltaTime;

    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public static IEnumerator FadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }

    void updateStatus()
    {
        /*if (!PlayerPrefs.HasKey("_food"))
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
        }*/
        List<int> values = new List<int>();
        values.Add(GlobalData.food);
        values.Add(GlobalData.happy);
        values.Add(GlobalData.clean);
        int lowest = values[0];
        int t = -1;
        for(int i = 0; i < 2; i++)
        {
            if (values[i] <= lowest)
            {
                lowest = values[i];
                t = i;
            }
        }
        //Debug.Log(t);
        //Debug.Log(lowest);
        if(lowest > 21)
        {
            //Debug.Log("t=" + t.ToString());
            int timeElapsed;
            switch(t)
            {
                case 0:
                    timeElapsed = (DateTime.Now - GlobalData.lastFed).Seconds;
                    break;
                case 1:
                    timeElapsed = (DateTime.Now - GlobalData.lastPlayed).Seconds;
                    break;
                case 2:
                    timeElapsed = (DateTime.Now - GlobalData.lastCleaned).Seconds;
                    break;
                case -1:
                default:
                    timeElapsed = 0;
                    break;
            }
            int koins = lowest - 21;
            //Debug.Log(koins);
            Debug.Log(timeElapsed);
            if (timeElapsed / 3 < koins)
            {
                GlobalData.KoinChange += timeElapsed / 3;
            }
            else GlobalData.KoinChange += koins;
            if(firstUpdate) 
              coinsAlert.SetActive(true);
            coins.text = GlobalData.KoinChange + " coins received";
            //Debug.Log(GlobalData.KoinChange);
        }
        GlobalData.food -= (DateTime.Now - GlobalData.lastFed).Seconds / 3;
        foodSlider.value = GlobalData.food;
        GlobalData.lastFed = DateTime.Now;

        GlobalData.happy -= (DateTime.Now - GlobalData.lastPlayed).Seconds / 3;
        happinessSlider.value = GlobalData.happy;
        GlobalData.lastPlayed = DateTime.Now;

        GlobalData.clean -= (DateTime.Now - GlobalData.lastCleaned).Seconds / 3;
        hygieneSlider.value = GlobalData.clean;
        GlobalData.lastCleaned = DateTime.Now;

        if (GlobalData.food < 0)
            GlobalData.food = 0;
        if (GlobalData.happy < 0)
            GlobalData.happy = 0;
        if (GlobalData.clean < 0)
            GlobalData.clean = 0;
        firstUpdate = false;
    }
    public void Feed()
    {
        if (GlobalData.food < 100)
        {
            if (GlobalData.food <= 85)
            {
                GlobalData.food += 15;
            }
            else GlobalData.food = 100;
            StartCoroutine(FillBar(foodSlider, 15));
            StartCoroutine(EmitLeaves());
            StartCoroutine(LookHappy());
            GlobalData.lastFed = DateTime.Now;
            foodSound.Play();

        }
        else
        {
            foodAlert.SetActive(true);
            playButton.interactable = false;
            foodButton.interactable = false;
            cleanButton.interactable = false;
        }
    }
    public void Clean()
    {
        if (GlobalData.clean < 100)
        {
            if (GlobalData.clean <= 85)
            {
                GlobalData.clean += 15;
            }
            else GlobalData.clean = 100;
            StartCoroutine(FillBar(hygieneSlider, 15));
            StartCoroutine(EmitBubbles());
            StartCoroutine(LookHappy());
            GlobalData.lastCleaned = DateTime.Now;
            cleanSound.Play();
            
        }
        else
        {
            cleanAlert.SetActive(true);
            playButton.interactable = false;
            foodButton.interactable = false;
            cleanButton.interactable = false;
        }
    }
    public void Play()
    {
        if (GlobalData.happy < 100)
        {
            if (GlobalData.happy <= 85)
            {
                GlobalData.happy += 15;
            }
            else GlobalData.happy = 100;
            StartCoroutine(FillBar(happinessSlider, 15));
            StartCoroutine(EmitHearts());
            StartCoroutine(LookHappy());
            GlobalData.lastPlayed = DateTime.Now;
            playSound.Play();
        }
        else 
        {
            playAlert.SetActive(true);
            playButton.interactable = false;
            foodButton.interactable = false;
            cleanButton.interactable = false;
        }
    }

    IEnumerator FillBar(Slider slider, int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            slider.value += 1;
            yield return null;
        }
    }
    IEnumerator EmptyBar(Slider slider, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            slider.value -= 0.01f;
            yield return null;
        }
    }
    IEnumerator LookHappy()
    {
        action = true;
        //happyeyes.SetActive(true);
        regeyes.SetActive(false);
        sad.SetActive(false);
        happy.SetActive(true);
        yield return new WaitForSeconds(0.75f);
        action = false;
        //happyeyes.SetActive(false);
        regeyes.SetActive(true);
    }
    IEnumerator EmitHearts()
    {
        hearts.Play();
        yield return null;

    }
    IEnumerator EmitLeaves()
    {
        food.Play();
        yield return null;
    }
    IEnumerator EmitBubbles()
    {
        bubbles.Play();
        yield return null;
    }
    public void CloseAlert()
    {
        foodAlert.SetActive(false);
        playAlert.SetActive(false);
        cleanAlert.SetActive(false);
        coinsAlert.SetActive(false);
        playButton.interactable = true;
        foodButton.interactable = true;
        cleanButton.interactable = true;
        firstLoginAlert.SetActive(false);
    }

    public void GoToTown()
    {
        SceneManager.LoadScene("MainScene");
    }

    //---------------------------------
    public const string DRAGGABLE_TAG = "UIDraggable";

    private bool dragging = false;

    private Vector2 originalPosition;
    private Transform objectToDrag;
    private Image objectToDragImage;

    List<RaycastResult> hitObjects = new List<RaycastResult>();
    private GameObject GetObjectUnderMouse()
    {
        var pointer = new PointerEventData(EventSystem.current);

        pointer.position = Input.mousePosition;

        EventSystem.current.RaycastAll(pointer, hitObjects);

        if (hitObjects.Count <= 0) return null;
        
        return hitObjects.First().gameObject;
    }

    private Transform GetDraggableTransformUnderMouse()
    {
        var clickedObject = GetObjectUnderMouse();

        // get top level object hit
        if (clickedObject != null && clickedObject.tag == DRAGGABLE_TAG)
        {
            return clickedObject.transform;
        }

        return null;
    }
    private Transform GetDraggableTransformUnderMouse2()
    {
        var clickedObject = GetObjectUnderMouse();

        // get top level object hit
        if (clickedObject != null && clickedObject.tag == "Koala")
        {
            return clickedObject.transform;
        }

        return null;
    }

}
