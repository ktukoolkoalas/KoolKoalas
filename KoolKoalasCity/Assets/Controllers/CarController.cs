﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float accelaretion = 8;
    [SerializeField] float turnSpeed = 5;

    Quaternion targetRotation;
    Rigidbody _rigidBody;

    Vector3 lastPosition;

    float _sideSlipAmount = 0;

    public GameObject Checkmarks;
    GameObject NextCheckmark;
    int NextCheckmarkIndex = 0;

    public Material CurrentCheckmarkMaterial;
    public Material InactiveCheckmarkMaterial;
    

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

    void SetRotationPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(0, rotationAngle, 0);
        }
    }

    void FixedUpdate()
    {
        float speed = _rigidBody.velocity.magnitude / 1000;

        float accelaretionInput = 0;
        if (Input.GetMouseButton(0))
        {
            accelaretionInput = accelaretion * Time.fixedDeltaTime;
        }
        else if (Input.GetMouseButton(1))
        {
            accelaretionInput = -1 * accelaretion * Time.fixedDeltaTime;
        }
        _rigidBody.AddRelativeForce(Vector3.forward * accelaretionInput);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Mathf.Clamp(speed, -1, 1) * Time.fixedDeltaTime);
    }
    /*
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision with " + collision.gameObject.name);
        if (collision.gameObject == NextCheckmark)
        {
            GetNextCheckmark();
        }
    }*/
    
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
        if(Checkmarks.transform.childCount <= ++NextCheckmarkIndex)
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
        
    }

}
