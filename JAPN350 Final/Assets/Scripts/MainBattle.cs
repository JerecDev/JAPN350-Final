using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public GameObject audioPlayer;
    public Image ohnishiSpriteRenderer;
    public Image playerSpriteRenderer;
    public Sprite playerHealthFive;
    public Sprite playerHealthFour;
    public Sprite playerHealthThree;
    public Sprite playerHealthTwo;
    public Sprite playerHealthOne;
    public Sprite ohnishiHealthFive;
    public Sprite ohnishiHealthFour;
    public Sprite ohnishiHealthThree;
    public Sprite ohnishiHealthTwo;
    public Sprite ohnishiHealthOne;
    private string question = "";
    private string answer = "";
    private string answerOne = "";
    private string answerTwo = "";
    private string answerThree = "";
    private string answerFour = "";
    private int playerHealth = 5;
    private int profHealth = 5;
    public System.Random ran = new System.Random();
    public AudioSource EffectPlayer;
    public AudioClip ohnishiHits;
    public AudioClip playerHits;

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
        playerSpriteRenderer.sprite = playerHealthFive;
        ohnishiSpriteRenderer.sprite = ohnishiHealthFive;
        buttonOneText.GetComponent<Text>().text = "";
        buttonTwoText.GetComponent<Text>().text = "";
        buttonThreeText.GetComponent<Text>().text = "";
        buttonFourText.GetComponent<Text>().text = "";
        buttonOne.onClick.AddListener(AnswerOne);
        buttonTwo.onClick.AddListener(AnswerTwo);
        buttonThree.onClick.AddListener(AnswerThree);
        buttonFour.onClick.AddListener(AnswerFour);
        audioPlayer = GameObject.FindWithTag("BattleAudio");
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
            EffectPlayer.PlayOneShot(playerHits, .5f);
            profHealth = profHealth - 1;
        }
        else
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Wrong Answer!");
            EffectPlayer.PlayOneShot(ohnishiHits, .5f);
            playerHealth = playerHealth - 1;
        }
        DeactivateButtons();
        CheckHealth();
    }

    void AnswerTwo()
    {
        if (answerTwo == answer)
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Correct Answer!");
            EffectPlayer.PlayOneShot(playerHits, .5f);
            profHealth = profHealth - 1;
        }
        else
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Wrong Answer!");
            EffectPlayer.PlayOneShot(ohnishiHits, .5f);
            playerHealth = playerHealth - 1;
        }
        DeactivateButtons();
        CheckHealth();
    }

    void AnswerThree()
    {
        if (answerThree == answer)
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Correct Answer!");
            EffectPlayer.PlayOneShot(playerHits, .5f);
            profHealth = profHealth - 1;
        }
        else
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Wrong Answer!");
            EffectPlayer.PlayOneShot(ohnishiHits, .5f);
            playerHealth = playerHealth - 1;
        }
        DeactivateButtons();
        CheckHealth();
    }

    void AnswerFour()
    {
        if (answerFour == answer)
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Correct Answer!");
            EffectPlayer.PlayOneShot(playerHits, .5f);
            profHealth = profHealth - 1;
        }
        else
        {
            TextBox.GetComponent<TypedEffect>().TypeThis("Wrong Answer!");
            EffectPlayer.PlayOneShot(ohnishiHits, .5f);
            playerHealth = playerHealth - 1;
        }
        DeactivateButtons();
        CheckHealth();
    }

    void GameStart()
    {
        StartCoroutine(FirstRound());
    }

    void CheckHealth()
    {
        //Player health checks, adjusting sprite
        if(playerHealth == 4)
        {
            playerSpriteRenderer.sprite = playerHealthFour;
        }
        if (playerHealth == 3)
        {
            playerSpriteRenderer.sprite = playerHealthThree;
        }
        if (playerHealth == 2)
        {
            playerSpriteRenderer.sprite = playerHealthTwo;
        }
        if (playerHealth == 1)
        {
            playerSpriteRenderer.sprite = playerHealthOne;
        }
        //Professor health checks, adjusting sprite
        if (profHealth == 4)
        {
            ohnishiSpriteRenderer.sprite = ohnishiHealthFour;
        }
        if (profHealth == 3)
        {
            ohnishiSpriteRenderer.sprite = ohnishiHealthThree;
        }
        if (profHealth == 2)
        {
            ohnishiSpriteRenderer.sprite = ohnishiHealthTwo;
        }
        if (profHealth == 1)
        {
            ohnishiSpriteRenderer.sprite = ohnishiHealthOne;
        }


        if (playerHealth <= 0)
        {
            StartCoroutine(CallOnLoss());
        }
        else if(profHealth <= 0)
        {
            StartCoroutine(CallOnWin());
        }
        else
        {
            StartCoroutine(SecondRound());
        }
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
        yield return new WaitForSeconds(3.5f);
        NewQuestion();
        yield break;
    }

    IEnumerator CallOnLoss()
    {
        TextBox.GetComponent<TypedEffect>().TypeThis("You have no more chances left!");
        yield return new WaitForSeconds(5f);
        TextBox.GetComponent<TypedEffect>().TypeThis("Player blacked out!");
        yield return new WaitForSeconds(5f);
        Destroy(audioPlayer);
        SceneManager.LoadScene(sceneName: "LoseScreen");
        yield break;
    }

    IEnumerator CallOnWin()
    {
        TextBox.GetComponent<TypedEffect>().TypeThis("Player defeated Ohnishi sensei!");
        yield return new WaitForSeconds(5f);
        TextBox.GetComponent<TypedEffect>().TypeThis("Player got an A+ for winning!");
        yield return new WaitForSeconds(5f);
        Destroy(audioPlayer);
        SceneManager.LoadScene(sceneName: "WinScreen");
        yield break;
    }
}