using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherCarController : CarController
{
    protected override void GameOver()
    {
        //Nothing, unless you want to show who won finnished
    }

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
        NextCheckmark = Checkmarks.transform.GetChild(0).gameObject;
        Debug.Log(NextCheckmark.transform.name);
        audio = gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.clip = SoundLow;
        audio.volume = 0.1f;
        audio.maxDistance = 100;
        audio.spatialBlend = 0.8f;
    }

    void FixedUpdate()
    {
        if(MovementEnabled == 1 && !audio.isPlaying)
        {
            audio.Play();
        }
        float speed = _rigidBody.velocity.magnitude / 1000;

        float accelaretionInput = accelaretion * Time.fixedDeltaTime * (1 - Mathf.Abs(_sideSlipAmount));

        _rigidBody.AddRelativeForce(Vector3.forward * accelaretionInput * trackMultiplier * MovementEnabled);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Mathf.Clamp(speed, -1, 1) * Time.fixedDeltaTime);
        realSpeed = _rigidBody.velocity.magnitude;
        if(realSpeed < 30)
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

        Vector3 target = (NextCheckmark.GetComponent<Collider>().ClosestPoint(transform.position) + NextCheckmark.transform.position)/2;
        Vector3 direction = target - transform.position;
        if (direction.magnitude > 30 && direction.magnitude > _rigidBody.velocity.magnitude )
        {
            direction = direction - _rigidBody.velocity * Mathf.Abs(_sideSlipAmount) * 1.8f;
        }
        float rotationAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler(0, rotationAngle, 0);

    }

    protected override void GetNextCheckmark()
    {
        if (Checkmarks.transform.childCount <= ++NextCheckmarkIndex)
        {
            NextCheckmarkIndex = 0;
            MarkLap();
        }
        NextCheckmark = NextCheckmark.transform.parent.GetChild(NextCheckmarkIndex).gameObject;
    }

    public override int GetRacePosition()
    {
        throw new System.NotImplementedException();
    }
}
