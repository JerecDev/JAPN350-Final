using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypedEffect : MonoBehaviour
{
    private float delay = 0.05f;
    public string fullText = "";
    private string currentText = "";

    public void TypeThis(string Message)
    {
        fullText = Message;
        StartCoroutine(ShowText());
        return;
    }

    IEnumerator ShowText()
    {
        for(int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }

        yield break;
    }
}
