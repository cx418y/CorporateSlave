using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blinking : MonoBehaviour
{
    private Blinking() { }
    //私有对象
    private static Blinking instance;

    //公有对象
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
    // public Image redDot; // 红色圆点
    public float blinkInterval = 0.5f; // 闪烁间隔

    private bool isBlinking = false;

    public GameObject whiteMail;

    void Awake()
    {
        // 检查是否已存在单例实例
        if (instance == null)
        {
            // 如果不存在，则将当前实例设置为单例，并标记为不可销毁
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 如果存在其他实例，则销毁当前实例
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // StartBlinking();
    }

    public void StartBlinking()
    {
        // 启动 Coroutine 来控制图片的闪烁
        isBlinking = true;
        SpriteRenderer redDot = whiteMail.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        Color color = redDot.color;
        // 修改透明度值
        color.a = 1;
        redDot.color = color;
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (isBlinking)
        {
            // 切换图片的显示状态
            SpriteRenderer icon = whiteMail.GetComponent<SpriteRenderer>();
            Color color = icon.color;
            // 修改透明度值
            color.a = 1-color.a;
            icon.color = color;

            SpriteRenderer redDot = whiteMail.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
            Color color2 = redDot.color;
            // 修改透明度值
            color2.a = 1 - color2.a;
            redDot.color = color2;

            yield return new WaitForSeconds(blinkInterval);
        }
    }

    public void StopBlinking()
    {
        Debug.Log("StopBlinking");
        // 停止 Coroutine
        isBlinking = false;
        StopCoroutine(Blink());
        SpriteRenderer icon = whiteMail.GetComponent<SpriteRenderer>();
        Color color = icon.color;
        // 修改透明度值
        color.a = 1;
        icon.color = color;

        SpriteRenderer redDot = whiteMail.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
        Color color2 = redDot.color;
        // 修改透明度值
        color2.a = 0;
        redDot.color = color2;
    }

    void OnDestroy()
    {
        // 销毁时停止 Coroutine
        StopBlinking();
    }

    /*void OnGUI()
    {
        // 设置红色圆点的位置到右上角
        RectTransform redDotRectTransform = redDot.GetComponent<RectTransform>();
        redDotRectTransform.anchorMin = new Vector2(1, 1);
        redDotRectTransform.anchorMax = new Vector2(1, 1);
        redDotRectTransform.pivot = new Vector2(1, 1);
        redDotRectTransform.anchoredPosition = new Vector2(-10, -10);
    }*/
}
