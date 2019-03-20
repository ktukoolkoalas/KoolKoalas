using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCard : MonoBehaviour
{

    public int fps = 60;
    public float rotateDegreePerSec = 180f;
    public bool isFaceUp = false;
    float waitTime = 0.1f / 60;
    bool isProcessing = false;
    const float FLIP_LIMIT_DEGREE = 180f;

    [SerializeField] private MemorySceneController controller;
    [SerializeField] private GameObject Back;

    public void OnMouseDown()
    {
        if(isFaceUp || !controller.CanReveal)
        {
            return;
        }
        StartCoroutine(flip());
        controller.CardRevealed(this);
    }
    IEnumerator flip()
    {
        isProcessing = true;

        bool done = false;
        while(!done)
        {
            float degree = rotateDegreePerSec * Time.deltaTime;
            if(isFaceUp)
            {
                degree = -degree;
            }

            transform.Rotate(new Vector3(0, degree, 0));
            if(FLIP_LIMIT_DEGREE < transform.eulerAngles.y)
            {
                transform.Rotate(new Vector3(0, -degree, 0));
                done = true;
            }

            yield return new WaitForSeconds(waitTime);
        }
        isFaceUp = !isFaceUp;
        isProcessing = false;
    }

    private int _id;
    public int id
    {
        get { return _id; }
    }

    public void ChangeSprite(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    
    public void Unreveal()
    {
        if (!isFaceUp)
        {
            return;
        }
        StartCoroutine(flip());
    }
}
