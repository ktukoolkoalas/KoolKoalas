using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FallingTrashScript : MonoBehaviour
{
    int verticalSpeed;
    int horizontalSpeed;
    public Sprite plastic;
    public Sprite glass;
    public Sprite paper;
    public Text scoreText;
    public Text livesLeftText;
    public int lifeCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = GlobalData.RecyclingGameScore.ToString();
        print(lifeCount);
        livesLeftText.text = lifeCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(1 * Time.deltaTime * horizontalSpeed * Input.GetAxis("Horizontal"), -1 * Time.deltaTime * verticalSpeed, 0);
        transform.Translate(vector);
        livesLeftText.text = lifeCount.ToString();
        scoreText.text = GlobalData.RecyclingGameScore.ToString();
        
        // ground
        if (transform.position.y < -4)
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

        if (lifeCount == 0)
        {
            //SceneManager.LoadScene("EndScene");
            //GlobalData.TrashGameDropping = false; 
            
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

         if (RightContainer(collision))
         {
             GlobalData.RecyclingGameScore++;
         }
         if (!RightContainer(collision) && lifeCount > 0)
         {
             lifeCount--;
             print(lifeCount + "minusas");
         }
    }
    private bool RightContainer (Collider2D collision)
    {
        if (this.GetComponent<SpriteRenderer>().sprite == paper && collision.gameObject.name == "PaperBin" || this.GetComponent<SpriteRenderer>().sprite == plastic && collision.gameObject.name == "PlasticBin" || this.GetComponent<SpriteRenderer>().sprite == glass && collision.gameObject.name == "GlassBin")
        {
            return true;
        }
        if (collision.gameObject.name == "ground")
            return false;

        return false;
    }
}
