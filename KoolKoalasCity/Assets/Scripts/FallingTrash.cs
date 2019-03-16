using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrash : MonoBehaviour
{
    public float delay = 0.05f;
    public GameObject trash;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
    }

    // Update is called once per frame
    void Spawn()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Instantiate(trash, new Vector3(1, 10, 0), Quaternion.identity);
    }
    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
