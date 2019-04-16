using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] float accelaretion = 8;
    [SerializeField] float turnSpeed = 5;

    Quaternion targetRotation;
    Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        SetRotationPoint();
    }

    void SetRotationPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if(plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            targetRotation = Quaternion.Euler(0, rotationAngle, 0);
        }
    }

    void FixedUpdate()
    {
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
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.fixedDeltaTime);
    }
}
