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
    
    public int gridRows = 2;
    public int gridCols = 4;
    public const float minOffsetX = 4f;
    public const float minOffsetY = -5f;
    public int _matches = 0;
 //   public int timeLeft = GlobalData.MemoryGameLevel * 20;
    public Camera Camera1;
    public Camera Camera2;
    public Camera Camera3;

    int[] MatchIDs;
    public int currentLevel;

    [SerializeField] private MainCard originalCard;
    [SerializeField] private Sprite[] images;
    private void Start()
    {
        timeLabel.text = "Time left: " + (GlobalData.MemoryGameLevel * 30).ToString();
        StartCoroutine(Counter());
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
    private IEnumerator Counter()
    {
        /*timeLeft -= Time.deltaTime();
        timeLabel.text = "Time left: " + timeLeft.ToString();
        if (timeLeft == 0)
        {
            SceneManager.LoadScene("MainScene");
        }*/
        int currCountdownValue = GlobalData.MemoryGameLevel * 30;
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            if (currCountdownValue == 0)
            {
                SceneManager.LoadScene("MainScene");
            }
            else timeLabel.text = "Time left: " + currCountdownValue.ToString();
        }
    }
    private int[] GetLevel()
    {
        switch (GlobalData.MemoryGameLevel)
        {
            case 2:
                int [] numbers = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, };
                currentLevel = 2;
                gridCols = 5;
                gridRows = 2;
                Camera1.enabled = false;
                Camera2.enabled = true;
                Camera3.enabled = false;
//                timeLeft = GlobalData.MemoryGameLevel * 20;
                return numbers;
            case 3:
                int[] numbers2 = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
                currentLevel = 3;
                gridCols = 6;
                gridRows = 3;
                Camera1.enabled = false;
                Camera2.enabled = false;
                Camera3.enabled = true;
//                timeLeft = GlobalData.MemoryGameLevel * 20;
                return numbers2;
            case 1:
            default:
                int[] numbers3 = { 0, 0, 1, 1, 2, 2, 3, 3 };
                currentLevel = 1;
                Camera1.enabled = true;
                Camera2.enabled = false;
                Camera3.enabled = false;
                return numbers3;
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
    [SerializeField] private TextMesh timeLabel;

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
            //_score++;
            //scoreLabel.text = "Score: " + _score;
            _matches++;
        }
        if(_firstRevealed.id != _secondRevealed.id)
        {
            //_score--;
            //scoreLabel.text = "Score: " + _score;
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
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene("GameScene");
        }
    }
}
