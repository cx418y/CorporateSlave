using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Blinking : MonoBehaviour
{
    // public GameObject whiteMail; // 要闪烁的图片
    // public Image redDot; // 红色圆点
    public float blinkInterval = 0.5f; // 闪烁间隔

    private bool isBlinking = false;

    void Awake()
    {
        Debug.Log("Awake");
        StartBlinking();
    }

    public void StartBlinking()
    {
        // 启动 Coroutine 来控制图片的闪烁
        isBlinking = true;
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        while (isBlinking)
        {
            // 切换图片的显示状态
            SpriteRenderer icon = GetComponent<SpriteRenderer>();
            Color color = icon.color;
            // 修改透明度值
            color.a = 1-color.a;
            icon.color = color;

            yield return new WaitForSeconds(blinkInterval);
        }
    }

    public void StopBlinking()
    {
        Debug.Log("StopBlinking");
        // 停止 Coroutine
        isBlinking = false;
        StopCoroutine(Blink());
        SpriteRenderer icon = GetComponent<SpriteRenderer>();
        Color color = icon.color;
        // 修改透明度值
        color.a = 1;
        icon.color = color;
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
