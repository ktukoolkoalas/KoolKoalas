using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCarController : CarController
{


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

    protected override void SetRotationPoint()
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

    protected override void GameOver()
    {
        SceneManager.LoadScene("GameScene");
    }


}
