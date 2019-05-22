using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarController : MonoBehaviour
{
    [SerializeField] protected float accelaretion = 2200;
    [SerializeField] protected float turnSpeed = 80;
    [SerializeField] protected float defaultTrackMultiplier = 1.5f;

    public float realSpeed = 0;

    protected Quaternion targetRotation;
    protected Rigidbody _rigidBody;

    protected float trackMultiplier = 1;

    Vector3 lastPosition;

    public float _sideSlipAmount = 0;

    public GameObject Checkmarks;
    protected GameObject NextCheckmark;
    public int NextCheckmarkIndex = 0;

    public int LapCount = 1;
    public int CurrLap = 0;

    public int MovementEnabled = 0;

    protected AudioSource audio;
    public AudioClip SoundLow;
    public AudioClip SoundMid;

    public float SideSlipAmount
    {
        get
        {
            return _sideSlipAmount;
        }
    }


    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        NextCheckmark = Checkmarks.transform.GetChild(0).gameObject;
        GetComponent<TargetIndicatorController>().Target = NextCheckmark;
        audio = gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.clip = SoundLow;
    }

    void Update()
    {
        SetRotationPoint();
        SetSideSlip();
    }

    void SetSideSlip()
    {
        Vector3 direction = transform.position - lastPosition;
        Vector3 movement = transform.InverseTransformDirection(direction);
        lastPosition = transform.position;

        _sideSlipAmount = movement.x;
    }

    abstract protected void SetRotationPoint();
    

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name + " (as " + gameObject.name + ")");
        if (collision.gameObject == NextCheckmark)
        {
            GetNextCheckmark();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name + " (as " + gameObject.name + ")");
        if (collision.gameObject.name == "Track")
        {
            trackMultiplier = defaultTrackMultiplier;
        }


    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Track")
        {
            trackMultiplier = 1;
        }

    }

    abstract protected void GetNextCheckmark();

    protected void MarkLap()
    {
        CurrLap++;
        if(LapCount <= CurrLap)
        {
            GameOver();
        }
    }

    abstract protected void GameOver();

    abstract public int GetRacePosition();

    public float GetDistanceToCheckmark()
    {
        Vector3 distance = transform.position - NextCheckmark.transform.position;
        return distance.magnitude;
    }

}
