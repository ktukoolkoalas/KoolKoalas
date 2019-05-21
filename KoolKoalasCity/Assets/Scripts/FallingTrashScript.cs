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
    public ParticleSystem Red;
    public ParticleSystem Green;
    // public AudioSource collisionSound;
    // public ParticleSystem particleEffect;


    // Start is called before the first frame update
    void Start()
    {
        GlobalData.RecyclingGameLifeCount = 3;
        GlobalData.RecyclingGameScore = 0;
        scoreText.text = GlobalData.RecyclingGameScore.ToString();
        livesLeftText.text = GlobalData.RecyclingGameLifeCount.ToString();
                            StartCoroutine(EmitCrosses());

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(1 * Time.deltaTime * horizontalSpeed * Input.GetAxis("Horizontal"), -1 * Time.deltaTime * verticalSpeed, 0);
        transform.Translate(vector);
        livesLeftText.text = GlobalData.RecyclingGameLifeCount.ToString();
        scoreText.text = GlobalData.RecyclingGameScore.ToString();

        if (GlobalData.RecyclingGameLifeCount <= 0)
        {
            Stop();
            SceneManager.LoadScene("EndScene");
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
        if (GlobalData.RecyclingGameLifeCount > 0)
        {
            //collisionSound.Play();
            if ((this.GetComponent<SpriteRenderer>().sprite == paper && collision.gameObject.name == "PaperBin" )|| (this.GetComponent<SpriteRenderer>().sprite == plastic && collision.gameObject.name == "PlasticBin" )|| (this.GetComponent<SpriteRenderer>().sprite == glass && collision.gameObject.name == "GlassBin"))
            {
                GlobalData.RecyclingGameScore++;
                StartCoroutine(EmitCheckMarks());
                MoveToTop();
            }
            else if (collision.gameObject.name == "PaperBin" || collision.gameObject.name == "PlasticBin" || collision.gameObject.name == "GlassBin" || collision.gameObject.name == "ground")
            {
                GlobalData.RecyclingGameLifeCount--;
                StartCoroutine(EmitCrosses());
                MoveToTop();
            }
            
        }
    }
        IEnumerator EmitCheckMarks()
        {
            Green.Play();
            yield return null;
        }
        IEnumerator EmitCrosses()
        {
            Red.Play();
            yield return null;
        }

}
