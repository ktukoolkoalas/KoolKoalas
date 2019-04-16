using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Button foodButton;
    public Button playButton;

    // Start is called before the first frame update
    void Start()
    {
        happy.SetActive(false);
        sad.SetActive(false);
        foodAlert.SetActive(false);
        playAlert.SetActive(false);
        foodSlider.interactable = false;
        happinessSlider.interactable = false;
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
                }
                objectToDrag.position = originalPosition;
                objectToDragImage.raycastTarget = true;
                objectToDrag = null;
            }

            dragging = false;
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
        else
        {
            foodAlert.SetActive(true);
            playButton.interactable = false;
            foodButton.interactable = false;
        }
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
        else 
        {
            playAlert.SetActive(true);
            playButton.interactable = false;
            foodButton.interactable = false;
        }
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
        playButton.interactable = true;
        foodButton.interactable = true;
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
