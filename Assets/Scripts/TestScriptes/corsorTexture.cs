using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTexture; // 你的光标图片

    void Start()
    {
        // 设置光标图片
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
