using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrashScript : MonoBehaviour
{
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        /*if (transform.position.y < -17)
        {
            float randomNumber = Random.Range(-19f, 19f);
            Vector3 newPosition = new Vector3(randomNumber, 17, 0);
            transform.position = newPosition;
        }*/
    }
}
