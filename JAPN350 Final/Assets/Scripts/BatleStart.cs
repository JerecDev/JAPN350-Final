using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatleStart : MonoBehaviour
{

    float m_distanceTraveled = 0f;
    public GameObject groundImage;
    public GameObject ohnishiSprite;
    bool colorFlip;

    void Start()
    {
        // 45, 195, 95
        groundImage.GetComponent<Renderer>().material.color = new Color(0.25f, 0.25f, 0.25f);
        // 255, 255, 255
        ohnishiSprite.GetComponent<Renderer>().material.color = new Color(0.25f, 0.25f, 0.25f);
    }

    void Update()
    {
        if (m_distanceTraveled < 13f)
        {
            Vector3 oldPosition = transform.position;
            transform.Translate(.05f, 0, 0 * Time.deltaTime);
            m_distanceTraveled += Vector3.Distance(oldPosition, transform.position);
        }
    }
}
