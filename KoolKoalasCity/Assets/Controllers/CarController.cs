using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CarController : MonoBehaviour
{
    [SerializeField] protected float accelaretion = 8;
    [SerializeField] protected float turnSpeed = 5;

    protected Quaternion targetRotation;
    protected Rigidbody _rigidBody;

    Vector3 lastPosition;

    float _sideSlipAmount = 0;

    public GameObject Checkmarks;
    GameObject NextCheckmark;
    int NextCheckmarkIndex = 0;

    public Material CurrentCheckmarkMaterial;
    public Material InactiveCheckmarkMaterial;

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
        NextCheckmark.GetComponent<MeshRenderer>().material = CurrentCheckmarkMaterial;
        Debug.Log("First Checkmark is " + NextCheckmark.name);
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

    void GetNextCheckmark()
    {
        if (Checkmarks.transform.childCount <= ++NextCheckmarkIndex)
        {
            NextCheckmarkIndex = 0;
            MarkLap();
        }
        NextCheckmark.GetComponent<MeshRenderer>().material = InactiveCheckmarkMaterial;
        NextCheckmark = NextCheckmark.transform.parent.GetChild(NextCheckmarkIndex).gameObject;
        NextCheckmark.GetComponent<MeshRenderer>().material = CurrentCheckmarkMaterial;
        Debug.Log("Next Checkpoint is " + NextCheckmarkIndex + 1);

    }

    void MarkLap()
    {
        CurrLap++;
        if(LapCount <= CurrLap)
        {
            GameOver();
        }
    }

    abstract protected void GameOver();

}
