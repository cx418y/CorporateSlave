using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blinking : MonoBehaviour
{
    private Blinking() { }
    //˽�ж���
    private static Blinking instance;

    //���ж���
    public static Blinking Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Blinking();
            }
            return instance;
        }
    }
    // public Image redDot; // ��ɫԲ��
    public float blinkInterval = 0.5f; // ��˸���

    private bool isBlinking = false;

    public GameObject whiteMail;

    void Awake()
    {
        // ����Ƿ��Ѵ��ڵ���ʵ��
        if (instance == null)
        {
            // ��������ڣ��򽫵�ǰʵ������Ϊ�����������Ϊ��������
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // �����������ʵ���������ٵ�ǰʵ��
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // StartBlinking();
    }

    public void StartBlinking()
    {
        // ���� Coroutine ������ͼƬ����˸
        isBlinking = true;
        SpriteRenderer redDot = whiteMail.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        Color color = redDot.color;
        // �޸�͸����ֵ
        color.a = 1;
        redDot.color = color;
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (isBlinking)
        {
            // �л�ͼƬ����ʾ״̬
            SpriteRenderer icon = whiteMail.GetComponent<SpriteRenderer>();
            Color color = icon.color;
            // �޸�͸����ֵ
            color.a = 1-color.a;
            icon.color = color;

            SpriteRenderer redDot = whiteMail.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            Color color2 = redDot.color;
            // �޸�͸����ֵ
            color2.a = 1 - color2.a;
            redDot.color = color2;

            yield return new WaitForSeconds(blinkInterval);
        }
    }

    public void StopBlinking()
    {
        Debug.Log("StopBlinking");
        // ֹͣ Coroutine
        isBlinking = false;
        StopCoroutine(Blink());
        SpriteRenderer icon = whiteMail.GetComponent<SpriteRenderer>();
        Color color = icon.color;
        // �޸�͸����ֵ
        color.a = 1;
        icon.color = color;

        SpriteRenderer redDot = whiteMail.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        Color color2 = redDot.color;
        // �޸�͸����ֵ
        color2.a = 0;
        redDot.color = color2;
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
