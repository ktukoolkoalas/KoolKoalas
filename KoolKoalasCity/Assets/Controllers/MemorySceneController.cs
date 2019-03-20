using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MemorySceneController : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float minOffsetX = 4f;
    public const float minOffsetY = 5f;
    public int _matches = 0;

    int[] MatchIDs;
    int currentLevel;

    [SerializeField] private MainCard originalCard;
    [SerializeField] private Sprite[] images;
    private void Start()
    {
        Vector3 startPos = originalCard.transform.position;
        int[] numbers = GetLevel();
        MatchIDs = ShuffleArray(numbers);

        for(int i = 0; i < gridCols; i++)
        {
            for(int j = 0; j < gridRows; j++)
            {
                MainCard card;
                if (i == 0 && j == 0)
                {
                    card = originalCard;
                }
                else
                {
                    card = Instantiate(originalCard) as MainCard;
                }
                int index = j * gridCols + i;
                int id = MatchIDs[index];
                card.ChangeSprite(id, images[id]);

                float posX = (minOffsetX * i) + startPos.x;
                float posY = (minOffsetY * j) + startPos.y;
                card.transform.position = new Vector3(posX, posY, startPos.z);
            }
        }
    }
    // for making more levels
    /*private void GetOffset(out float offsetX, out float offsetY)
    {
        
    }*/

    private int[] GetLevel()
    {
        switch (GlobalData.MemoryGameLevel)
        {
            default:
                int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
                currentLevel = 1;
                return numbers;
        }
    }
    private int[] ShuffleArray(int[] numbers)
    {
        int[] newArray = numbers.Clone() as int[];
        for(int i = 0; i < newArray.Length; i++)
        {
            int tmp = newArray[i];
            int r = Random.Range(i, newArray.Length);
            newArray[i] = newArray[r];
            newArray[r] = tmp;
        }
        return newArray;
    }

    private MainCard _firstRevealed;
    private MainCard _secondRevealed;

    private int _score = 0;
    [SerializeField] private TextMesh scoreLabel;

    public bool CanReveal
    {
        get { return _secondRevealed == null; }
    }

    public void CardRevealed(MainCard card)
    {
        if(_firstRevealed == null)
        {
            _firstRevealed = card;
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        } 
    }
    
    private IEnumerator CheckMatch()
    {
        if(_firstRevealed.id == _secondRevealed.id)
        {
            _score++;
            scoreLabel.text = "Score: " + _score;
            _matches++;
        }
        else
        {
            _score--;
            scoreLabel.text = "Score: " + _score;
            yield return new WaitForSeconds(1.5f);
            _secondRevealed.Unreveal();
            _firstRevealed.Unreveal();
           
        }
        _firstRevealed = null;
        _secondRevealed = null;
        if(_matches == MatchIDs.Length/2)
        {
            if(GlobalData.MemoryGameBeaten < currentLevel)
            {
                GlobalData.MemoryGameBeaten++;
                GlobalData.MemoryGameLevel++;
                GlobalData.NeedToUpdateProgress = true;
            }
            SceneManager.LoadScene("GameScene");
        }
    }
}
