using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneChange : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;
    int startFlash = 3;
    public Image flashImage;
    public int flashTimes;
    public GameObject battleMusic;
    public GameObject menuMusic;

    void Start()
    {
        startButton.onClick.AddListener(StartGame);
        quitButton.onClick.AddListener(QuitGame);
        menuMusic.gameObject.SetActive(true);
    }

    void StartGame()
    {
        
        battleMusic.gameObject.SetActive(true);
        DontDestroyOnLoad(battleMusic.gameObject);
        StartCoroutine(waiter());
        menuMusic.gameObject.SetActive(false);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void Update()
    {
        if (startFlash == 1)
        {
            Color Opaque = new Color(1, 1, 1, 1);
            flashImage.color = Color.Lerp(flashImage.color, Opaque, 10 * Time.deltaTime);
            if (flashImage.color.a >= 0.8) //Scaling to Opaque
            {
                startFlash = 2;
            }
        }
        if (startFlash == 2)
        {
            Color Transparent = new Color(1, 1, 1, 0);
            flashImage.color = Color.Lerp(flashImage.color, Transparent, 10 * Time.deltaTime);
            if (flashImage.color.a <= 0.1) //Scaling back down to transparency
            {
                if (flashTimes == 0)
                {
                    
                    SceneManager.LoadScene(sceneName: "BattleScene");
                    
                }
                flashTimes = flashTimes - 1;
                startFlash = 1;
            }
        }
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(.55f);
        flashImage.gameObject.SetActive(true);
        startFlash = 1;
    }
}
