using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarCameraController : MonoBehaviour
{
    [SerializeField] Transform observable;
    [SerializeField] float aheadSpeed;
    [SerializeField] float followDamping;
    [SerializeField] float cameraHeight;

    Rigidbody _observableRigidBody;
    

    [SerializeField] Text PositionText;
    [SerializeField] Text CountDownText;
    [SerializeField] Text LapText;


    // Start is called before the first frame update
    void Start()
    {
        _observableRigidBody = observable.GetComponent<Rigidbody>();
        StartCoroutine(CountDownRace());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainScene");
        }

        if (observable == null) return;


        Vector3 targetPosition = observable.position + Vector3.up * cameraHeight + _observableRigidBody.velocity * aheadSpeed;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followDamping * Time.deltaTime);

        //update canvas
        CarController car = observable.GetComponent<CarController>();
        PositionText.text = car.GetRacePosition() + "/" + observable.parent.childCount;

        LapText.text = car.CurrLap + "/" + car.LapCount;
    }

    IEnumerator CountDownRace()
    {
        //float runtime = 1f;
        for (int i = 3; i > 0; i--)
        {
            CountDownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }
        CountDownText.text = "";
        Transform Parent = observable.parent;
        for(int j = 0; j < Parent.childCount; j++)
        {
            Parent.GetChild(j).GetComponent<CarController>().MovementEnabled = 1;
        }
    }
}
