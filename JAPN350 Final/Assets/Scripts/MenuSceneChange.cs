using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneChange : MonoBehaviour
{
    public Button startButton;
    bool startFlash = false;
    public Image flashImage;
    public int flashTimes = 10;

    void Start()
    {
        startButton.onClick.AddListener(TaskOnClickOne);
    }

    void TaskOnClickOne()
    {
        startFlash = true;
        flashImage.gameObject.SetActive(true);
    }

    void Update()
    {
        if (startFlash)
        {

            Color Opaque = new Color(1, 1, 1, 1);
            flashImage.color = Color.Lerp(flashImage.color, Opaque, 6 * Time.deltaTime);
            if (flashImage.color.a >= 0.8) //Scaling to Opaque
            {
                startFlash = false;
            }
        }
        if (!startFlash)
        {
            Color Transparent = new Color(1, 1, 1, 0);
            flashImage.color = Color.Lerp(flashImage.color, Transparent, 6 * Time.deltaTime);
            if (flashImage.color.a <= 0.1) //Scaling back down to transparency
            {
                if (flashTimes == 0)
                {
                    SceneManager.LoadScene(sceneName: "BattleScene");
                }
                flashTimes = flashTimes - 1;
                startFlash = true;
            }
        }
    }
}
