using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCarController : CarController
{

    public Material CurrentCheckmarkMaterial;
    public Material InactiveCheckmarkMaterial;

    bool LapCheck;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        NextCheckmark = Checkmarks.transform.GetChild(0).gameObject;
        NextCheckmark.GetComponent<MeshRenderer>().material = CurrentCheckmarkMaterial;
        Debug.Log("First Checkmark is " + NextCheckmark.name);
        GetComponent<TargetIndicatorController>().Target = NextCheckmark;
        audio = gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.clip = SoundLow;
        audio.volume = 0.5f;
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
        if(MovementEnabled == 1 && accelaretionInput != 0 && !audio.isPlaying)
        {
            audio.Play();
        }
        else if (MovementEnabled == 1 && accelaretionInput == 0 && audio.isPlaying)
        {
            audio.Stop();
        }
        _rigidBody.AddRelativeForce(Vector3.forward * accelaretionInput * trackMultiplier * MovementEnabled);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Mathf.Clamp(speed, -1, 1) * Time.fixedDeltaTime);
        realSpeed = _rigidBody.velocity.magnitude;
        if (realSpeed < 30)
        {
            audio.clip = SoundLow;
        }
        else
        {
            audio.clip = SoundMid;
        }
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
        //SceneManager.LoadScene("GameScene");
        for(int i = 0; i < transform.parent.childCount; i++)
        {
            transform.parent.GetChild(i).GetComponent<CarController>().MovementEnabled = 0;
            Camera.main.gameObject.GetComponent<CarCameraController>().ShowScore();
        }
    }

    protected override void GetNextCheckmark()
    {
        if (LapCheck)
        {
            MarkLap();
        }
        if (Checkmarks.transform.childCount <= ++NextCheckmarkIndex)
        {
            NextCheckmarkIndex = 0;
            LapCheck = true;
        }
        NextCheckmark.GetComponent<MeshRenderer>().material = InactiveCheckmarkMaterial;
        NextCheckmark = NextCheckmark.transform.parent.GetChild(NextCheckmarkIndex).gameObject;
        NextCheckmark.GetComponent<MeshRenderer>().material = CurrentCheckmarkMaterial;
        Debug.Log("Next Checkpoint is " + NextCheckmarkIndex + 1);
        GetComponent<TargetIndicatorController>().Target = NextCheckmark;

    }

    public override int GetRacePosition()
    {
        int position = 1;
        for(int i = 0; i < transform.parent.childCount; i++)
        {
            CarController car = transform.parent.GetChild(i).GetComponent<CarController>();
            if(car.CurrLap > CurrLap)
            {
                position++;
            }
            else if(car.CurrLap == CurrLap && car.NextCheckmarkIndex > NextCheckmarkIndex)
            {
                position++;
            }
            else if(car.CurrLap == CurrLap && car.NextCheckmarkIndex == NextCheckmarkIndex && car.GetDistanceToCheckmark() < GetDistanceToCheckmark())
            {
                position++;
            }
        }
        return position;
    }
}
