using UnityEngine;
using TMPro;

public class ModifyTextMeshProText : MonoBehaviour
{
    public TextMeshProUGUI textMeshProText; // 引用 TextMeshPro 组件

    void Start()
    {
        // 确保在 Inspector 视图中将 TextMeshPro 组件分配给此变量
        if (textMeshProText == null)
        {
            Debug.LogError("TextMeshPro component is not assigned!");
        }
    }

    // 一个示例方法来修改 TextMeshPro 文本内容
    public void ChangeText(string newText)
    {
        textMeshProText.text = newText;
    }
}
