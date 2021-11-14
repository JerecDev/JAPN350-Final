using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartScript : MonoBehaviour
{
    public Button restartButton;
    public GameObject lossMusic;
    public GameObject winMusic;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        restartButton.onClick.AddListener(RestartGame);
        if (currentScene.name == "LoseScreen")
        {
            lossMusic.gameObject.SetActive(true);
        }
        if (currentScene.name == "WinScreen")
        {
            winMusic.gameObject.SetActive(true);
        }
    }

    void RestartGame()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}
