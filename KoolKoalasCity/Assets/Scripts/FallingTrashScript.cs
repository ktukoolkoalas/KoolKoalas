using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrashScript : MonoBehaviour
{
    int verticalSpeed;
    int horizontalSpeed;
    public Sprite plastic;
    public Sprite glass;
    public Sprite paper;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(1 * Time.deltaTime * horizontalSpeed * Input.GetAxis("Horizontal"), -1 * Time.deltaTime * verticalSpeed, 0);
        transform.Translate(vector);

        // ground
        if (transform.position.y < -3)
        {
            MoveToTop();
        }

        //left side of the screen
        if (transform.position.x < -9.8f)
        {
            transform.position = new Vector3(9.85f, transform.position.y, 0);
        }

        //right side of the screen
        if (transform.position.x > 9.85f)
        {
            transform.position = new Vector3(-9.8f, transform.position.y, 0);
        }

    }

    public void Stop()
    {
        verticalSpeed = horizontalSpeed = 0;
        GlobalData.TrashGameDropping = false;
    }

    public void Drop(int vSpeed, int hSpeed)
    {
        verticalSpeed = vSpeed;
        horizontalSpeed = hSpeed;
    }

    void MoveToTop()
    {
        Stop();
        float randomNumber = Random.Range(-8.7f, 8.7f);
        Vector3 newPosition = new Vector3(randomNumber, 6, 0);
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveToTop();
        

        if (this.GetComponent<SpriteRenderer>().sprite == paper && collision.gameObject.name == "PaperBin" || this.GetComponent<SpriteRenderer>().sprite == plastic && collision.gameObject.name == "PlasticBin" || this.GetComponent<SpriteRenderer>().sprite == glass && collision.gameObject.name == "GlassBin")
        {
            Debug.Log("yeyyyyyyyy");
        }
    }
}
