using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatleStart : MonoBehaviour
{

    float m_distanceTraveled = 0f;
    public GameObject groundImage;
    public GameObject ohnishiSprite;
    public SpriteRenderer spriteRenderer;
    public Sprite ohnishiSpriteOne;
    public Sprite ohnishiSpriteTwo;
    public Sprite ohnishiSpriteThree;
    public Sprite ohnishiSpriteFour;
    public GameObject healthBoxOhnishi;
    private Color originalColor;
    bool colorFlip;

    void Start()
    {
        originalColor = ohnishiSprite.GetComponent<Renderer>().material.color;
        // 45, 195, 95
        groundImage.GetComponent<Renderer>().material.color = new Color(0.25f, 0.25f, 0.25f);
        // 255, 255, 255
        ohnishiSprite.GetComponent<Renderer>().material.color = new Color(0.25f, 0.25f, 0.25f);
        StartCoroutine(OhnishiAnimation());
    }

    void Update()
    {
        if (m_distanceTraveled < 13f)
        {
            Vector3 oldPosition = transform.position;
            transform.Translate(.05f, 0, 0 * Time.deltaTime);
            m_distanceTraveled += Vector3.Distance(oldPosition, transform.position);
        }
        else
        {
            groundImage.GetComponent<Renderer>().material.color = new Color(.176f, .765f, .373f);
            ohnishiSprite.GetComponent<Renderer>().material.color = originalColor;
            healthBoxOhnishi.gameObject.SetActive(true);
        }
    }

    IEnumerator OhnishiAnimation()
    {
        spriteRenderer.sprite = ohnishiSpriteOne;
        yield return new WaitForSeconds(1.6f);
        spriteRenderer.sprite = ohnishiSpriteTwo;
        yield return new WaitForSeconds(.3f);
        spriteRenderer.sprite = ohnishiSpriteOne;
        yield return new WaitForSeconds(.3f);
        spriteRenderer.sprite = ohnishiSpriteTwo;
        yield return new WaitForSeconds(.3f);
        spriteRenderer.sprite = ohnishiSpriteOne;
        yield return new WaitForSeconds(.3f);
        spriteRenderer.sprite = ohnishiSpriteTwo;
        yield return new WaitForSeconds(.3f);
        spriteRenderer.sprite = ohnishiSpriteOne;
        yield return new WaitForSeconds(.3f);
        spriteRenderer.sprite = ohnishiSpriteThree;
        yield return new WaitForSeconds(1f);
        spriteRenderer.sprite = ohnishiSpriteFour;
        yield break;
    }
}
