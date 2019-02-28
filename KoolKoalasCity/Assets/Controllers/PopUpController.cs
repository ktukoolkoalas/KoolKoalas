using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpController : MonoBehaviour {

    bool QuestionAnswered;
    Question[] Questions;
	// Use this for initialization
	void Start () {
        QuestionAnswered = false;
        GetQuestion();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetQuestion()
    {
        //retrieve random questions from file
        if (Questions.Length == 0)
        {
            //create sample question
        }
    }

    public class Question
    {
        public string QuestionString { get; private set; }
        public string[] Options { get; private set; }

        public Question(string question, string correctOption, string option2, string option3, string option4)
        {
            //fill
        }

    }
}
