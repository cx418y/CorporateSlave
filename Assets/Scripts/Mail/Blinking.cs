using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blinking : MonoBehaviour
{
    // public GameObject whiteMail; // Ҫ��˸��ͼƬ
    // public Image redDot; // ��ɫԲ��
    public float blinkInterval = 0.5f; // ��˸���

    private bool isBlinking = false;

    void Awake()
    {
        Debug.Log("Awake");
        StartBlinking();
    }

    public void StartBlinking()
    {
        // ���� Coroutine ������ͼƬ����˸
        isBlinking = true;
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (isBlinking)
        {
            // �л�ͼƬ����ʾ״̬
            SpriteRenderer icon = GetComponent<SpriteRenderer>();
            Color color = icon.color;
            // �޸�͸����ֵ
            color.a = 1-color.a;
            icon.color = color;

            yield return new WaitForSeconds(blinkInterval);
        }
    }

    public void StopBlinking()
    {
        Debug.Log("StopBlinking");
        // ֹͣ Coroutine
        isBlinking = false;
        StopCoroutine(Blink());
        SpriteRenderer icon = GetComponent<SpriteRenderer>();
        Color color = icon.color;
        // �޸�͸����ֵ
        color.a = 1;
        icon.color = color;
    }

    void OnDestroy()
    {
        // ����ʱֹͣ Coroutine
        StopBlinking();
    }

    /*void OnGUI()
    {
        // ���ú�ɫԲ���λ�õ����Ͻ�
        RectTransform redDotRectTransform = redDot.GetComponent<RectTransform>();
        redDotRectTransform.anchorMin = new Vector2(1, 1);
        redDotRectTransform.anchorMax = new Vector2(1, 1);
        redDotRectTransform.pivot = new Vector2(1, 1);
        redDotRectTransform.anchoredPosition = new Vector2(-10, -10);
    }*/
}
