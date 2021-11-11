using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBattle : MonoBehaviour
{
    public Text buttonOneText;
    public Text buttonTwoText;
    public Text buttonThreeText;
    public Text buttonFourText;
    public Button buttonOne;
    public Button buttonTwo;
    public Button buttonThree;
    public Button buttonFour;
    public GameObject TextBox;
    public string question = "";
    public string answer = "";
    public string answerOne = "";
    public string answerTwo = "";
    public string answerThree = "";
    public string answerFour = "";
    public System.Random ran = new System.Random();

    private List<string> Questions = new List<string>()
    {
        "Nannensee Desuka?",
        "Goshusshin wa?",
        "Naniga Sukidesuka?",
        "Kyoo no otenki wa?"
    };

    private List<string> Answers = new List<string>()
    {
        "Sannensee desu",
        "Salinas desu",
        "Pizza desu",
        "Hare desu"
    };

    private List<string> AnswerList = new List<string>();

    void Start()
    {
        DeactivateButtons();
        buttonOneText.GetComponent<Text>().text = "";
        buttonTwoText.GetComponent<Text>().text = "";
        buttonThreeText.GetComponent<Text>().text = "";
        buttonFourText.GetComponent<Text>().text = "";
        buttonOne.onClick.AddListener(AnswerOne);
        buttonTwo.onClick.AddListener(AnswerTwo);
        buttonThree.onClick.AddListener(AnswerThree);
        buttonFour.onClick.AddListener(AnswerFour);
        GameStart();
    }

    void ActivateButtons()
    {
        buttonOne.gameObject.SetActive(true);
        buttonTwo.gameObject.SetActive(true);
        buttonThree.gameObject.SetActive(true);
        buttonFour.gameObject.SetActive(true);
    }
    
    void DeactivateButtons()
    {
        buttonOne.gameObject.SetActive(false);
        buttonTwo.gameObject.SetActive(false);
        buttonThree.gameObject.SetActive(false);
        buttonFour.gameObject.SetActive(false);
    }

    void AnswerOne()
    {
        if(answerOne == answer)
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Correct Answer!");
        }
        else
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Wrong Answer!");
        }
        DeactivateButtons();
        StartCoroutine(SecondRound());
    }

    void AnswerTwo()
    {
        if (answerTwo == answer)
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Correct Answer!");
        }
        else
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Wrong Answer!");
        }
        DeactivateButtons();
        StartCoroutine(SecondRound());
    }

    void AnswerThree()
    {
        if (answerThree == answer)
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Correct Answer!");
        }
        else
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Wrong Answer!");
        }
        DeactivateButtons();
        StartCoroutine(SecondRound());
    }

    void AnswerFour()
    {
        if (answerFour == answer)
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Correct Answer!");
        }
        else
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Wrong Answer!");
        }
        DeactivateButtons();
        StartCoroutine(SecondRound());
    }

    void GameStart()
    {
        StartCoroutine(FirstRound());
    }

    void NewQuestion()
    {
        int answerIndex = ran.Next(0, 4);
        int newAnswer = 0;
        answer = Answers[answerIndex];
        question = Questions[answerIndex];
        TextBox.GetComponent<TypedEffect>().TypeThis(question);
        AnswerList.Add(Answers[answerIndex]);

        while(AnswerList.Count < 4)
        {
            newAnswer = ran.Next(0, 4);
            if(!AnswerList.Contains(Answers[newAnswer]))
            {
                AnswerList.Add(Answers[newAnswer]);
            }
        }

        ActivateButtons();

        newAnswer = ran.Next(0, AnswerList.Count);
        buttonOneText.GetComponent<Text>().text = AnswerList[newAnswer];
        answerOne = AnswerList[newAnswer];
        AnswerList.RemoveAt(newAnswer);

        newAnswer = ran.Next(0, AnswerList.Count);
        buttonTwoText.GetComponent<Text>().text = AnswerList[newAnswer];
        answerTwo = AnswerList[newAnswer];
        AnswerList.RemoveAt(newAnswer);

        newAnswer = ran.Next(0, AnswerList.Count);
        buttonThreeText.GetComponent<Text>().text = AnswerList[newAnswer];
        answerThree = AnswerList[newAnswer];
        AnswerList.RemoveAt(newAnswer);

        newAnswer = ran.Next(0, AnswerList.Count);
        buttonFourText.GetComponent<Text>().text = AnswerList[newAnswer];
        answerFour = AnswerList[newAnswer];
        AnswerList.RemoveAt(newAnswer);
    }

    IEnumerator FirstRound()
    {
        TextBox.GetComponent<TypedEffect>().TypeThis("Ohnishi-sensei would like to battle!");
        yield return new WaitForSeconds(5f);
        NewQuestion();
        yield break;
    }

    IEnumerator SecondRound()
    {
        yield return new WaitForSeconds(5f);
        NewQuestion();
    }
}