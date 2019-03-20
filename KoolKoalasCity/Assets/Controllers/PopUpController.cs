using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpController : MonoBehaviour {

    bool QuestionShowing;
    bool AnswerAccepted;
    bool AnswerCorrect;
    Question[] Questions;
    public Text QuestionText;
    public Text Option1;
    public Text Option2;
    public Text Option3;
    public Text Option4;
    Text CurrentAnswer;
    Question CurrentQuestion;

    public int PopupWaitTimeInS = 5;
    public int CoinReward = 50;
	// Use this for initialization
	void Start () {
        QuestionShowing = true;
        AnswerAccepted = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (AnswerAccepted)
        {
            StartCoroutine(ShowingResult(AnswerCorrect, CurrentAnswer));
        }
	}

    public void RetrieveQuestions()
    {
        //retrieve questions from file
        if (Questions == null||Questions.Length == 0) //if no questions found
        {
            Questions = new Question[1];
            Questions[0] = new Question("What do Koalas eat?", "Eucalyptus leaves", "Bamboo trees", "Hay", "Smaller animals");
        }
    }

    public void OpenPopUp()
    {
        GlobalData.PopUpCounter--;
        print("sumazeja popup");
        if (QuestionShowing)
        {
            return;
        }
        gameObject.SetActive(true);
        gameObject.transform.SetAsLastSibling();
        RetrieveQuestions();
        System.Random rnd = new System.Random();
        int index = rnd.Next(0, Questions.Length);
        CurrentQuestion = Questions[index];
        ShowQuestion(Questions[index]);
        QuestionShowing = true;
        AnswerAccepted = false;
    }

    public void CheckAnswer(Text answer)
    {
        if(CurrentQuestion == null)
        {
            Console.WriteLine("There is no current question!!");
            return;
        }
        if (AnswerAccepted)
        {
            Console.WriteLine("Answer is already made");
            //do nothing
            return;
        }
        AnswerAccepted = true;
        CurrentAnswer = answer;
        AnswerCorrect = CurrentQuestion.IsAnswerCorrect(answer.text);
        if (AnswerCorrect)
        {
            GlobalData.KoinChange += CoinReward;
            GlobalData.HeartChange++;
        }
    }

    public void ClosePopup()
    {
        if (AnswerAccepted)
        {
            return;
        }
        gameObject.SetActive(false);
        QuestionShowing = false;
    }

    

    public void ShowQuestion(Question question)
    {
        if(question == null)
        {
            Console.WriteLine("No question given while trying to show it!!");
            return;
        }
        if (!question.IsComplete())
        {
            Console.WriteLine("Given question has missing information while trying to show it!!!");
            return;
        }
        QuestionText.text = question.QuestionString;
        List<string> options = question.GetOptions();
        System.Random rnd = new System.Random();
        string[] randomizedOption = new string[4];
        for (int i = 0; 0 < options.Count; i++)
        {
            int index = rnd.Next(0, options.Count - 1);
            randomizedOption[i] = options[index];
            options.RemoveAt(index);
        }
        Option1.text = randomizedOption[0];
        Option1.transform.parent.GetComponent<Image>().color = Color.white;
        Option2.text = randomizedOption[1];
        Option2.transform.parent.GetComponent<Image>().color = Color.white;
        Option3.text = randomizedOption[2];
        Option3.transform.parent.GetComponent<Image>().color = Color.white;
        Option4.text = randomizedOption[3];
        Option4.transform.parent.GetComponent<Image>().color = Color.white;

    }

    public class Question
    {
        public string QuestionString { get; private set; }
        private List<string> Options { get; set; }

        public Question(string question, string correctOption, string option2, string option3, string option4)
        {
            QuestionString = question;
            Options = new List<string>();
            Options.Add(correctOption);
            Options.Add(option2);
            Options.Add(option3);
            Options.Add(option4);
        }

        public bool IsComplete()
        {
            return QuestionString != null && Options[0] != null && Options[1] != null && Options[2] != null && Options[3] != null;
        }

        public List<string> GetOptions()
        {
            List<string> copyOfOptions = new List<string>();
            foreach(string option in Options)
            {
                copyOfOptions.Add(option);
            }
            return copyOfOptions;
        }

        public bool IsAnswerCorrect(string answer)
        {
            return answer == Options[0];
        }

    }

    private IEnumerator ShowingResult(bool answerCorrect, Text answer)
    {
        Color color = Color.red;
        if (answerCorrect)
        {
            color = Color.green;
        }
        answer.transform.parent.GetComponent<Image>().color = color;
        yield return new WaitForSecondsRealtime (PopupWaitTimeInS);
        ClosePopup();
        AnswerAccepted = false;
    }
}
