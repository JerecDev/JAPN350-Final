using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;
    public AudioSource EffectPlayer;
    public AudioClip lossSound;
    public AudioClip winSound;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        restartButton.onClick.AddListener(RestartGame);
        quitButton.onClick.AddListener(QuitGame);
        if (currentScene.name == "LoseScreen")
        {
            EffectPlayer.PlayOneShot(lossSound, .5f);
        }
        if (currentScene.name == "WinScreen")
        {
            EffectPlayer.PlayOneShot(winSound, .5f);
        }
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void RestartGame()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}
