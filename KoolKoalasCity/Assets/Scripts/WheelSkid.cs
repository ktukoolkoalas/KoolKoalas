using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelSkid : MonoBehaviour
{

    [SerializeField] float intensityModifier = 1.5f;

    SkidmarksController skidmarksController;
    CarController car;
    public ParticleSystem currParticleSystem;

    int lastSkidId = -1;
    // Start is called before the first frame update
    void Start()
    {
        skidmarksController = FindObjectOfType<SkidmarksController>();
        car = GetComponentInParent<CarController>();
        currParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float intensity = car.SideSlipAmount;
        if(intensity < 0) { intensity = -intensity; }

        if (intensity > 0.2f)
        {

            lastSkidId = skidmarksController.AddSkidMark(transform.position, transform.up, intensity * intensityModifier, lastSkidId);
            if(currParticleSystem != null && !currParticleSystem.isPlaying)
            {
                currParticleSystem.Play();
            }
        }
        else
        {
            lastSkidId = -1;

            if (currParticleSystem != null && currParticleSystem.isPlaying)
            {
                currParticleSystem.Stop();
            }
        }

    }
}
