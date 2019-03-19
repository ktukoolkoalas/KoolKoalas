using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTrashScript : MonoBehaviour
{
    public int speed;
    public Sprite plastic;
    public Sprite glass;
    public Sprite paper;
    public Sprite[] trashes = new Sprite[3];
    // Start is called before the first frame update
    void Start()
    {
        speed = 5;
        this.GetComponent<SpriteRenderer>().sprite = trashes[Random.Range(0, 2)];
        trashes[0] = plastic;
        trashes[1] = glass;
        trashes[2] = paper;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(1 * Time.deltaTime * speed * Input.GetAxis("Horizontal"), -1 * Time.deltaTime * speed, 0);
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

    void MoveToTop()
    {
        float randomNumber = Random.Range(-8.7f, 8.7f);
        Vector3 newPosition = new Vector3(randomNumber, 6, 0);
        transform.position = newPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MoveToTop();
        this.GetComponent<SpriteRenderer>().sprite = trashes[Random.Range(0, 2)];

        if (this.GetComponent<SpriteRenderer>().sprite == paper && collision.gameObject.name == "PaperBin" || this.GetComponent<SpriteRenderer>().sprite == plastic && collision.gameObject.name == "PlasticBin" || this.GetComponent<SpriteRenderer>().sprite == glass && collision.gameObject.name == "GlassBin")
        {
            Debug.Log("yeyyyyyyyy");
        }
        else
            Destroy(this.gameObject);
    }
}
