using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSkid : MonoBehaviour
{

    [SerializeField] float intensityModifier = 1.5f;

    SkidmarksController skidmarksController;
    CarController car;
    ParticleSystem particleSystem;

    int lastSkidId = -1;
    // Start is called before the first frame update
    void Start()
    {
        skidmarksController = FindObjectOfType<SkidmarksController>();
        car = GetComponentInParent<CarController>();
        particleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float intensity = car.SideSlipAmount;
        if(intensity < 0) { intensity = -intensity; }

        if (intensity > 0.1f)
        {

            lastSkidId = skidmarksController.AddSkidMark(transform.position, transform.up, intensity * intensityModifier, lastSkidId);
            if(particleSystem != null && !particleSystem.isPlaying)
            {
                particleSystem.Play();
            }
        }
        else
        {
            lastSkidId = -1;

            if (particleSystem != null && !particleSystem.isPlaying)
            {
                particleSystem.Stop();
            }
        }
    }
}
