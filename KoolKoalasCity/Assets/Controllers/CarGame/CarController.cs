using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarController : MonoBehaviour
{
    [SerializeField] protected float accelaretion = 2200;
    [SerializeField] protected float turnSpeed = 80;

    protected Quaternion targetRotation;
    protected Rigidbody _rigidBody;

    Vector3 lastPosition;

    float _sideSlipAmount = 0;

    public GameObject Checkmarks;
    protected GameObject NextCheckmark;
    protected int NextCheckmarkIndex = 0;

    int LapCount = 1;
    int CurrLap = 0;


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
        Debug.Log("Collision with " + collision.gameObject.name);
        if (collision.gameObject == NextCheckmark)
        {
            GetNextCheckmark();
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

}
