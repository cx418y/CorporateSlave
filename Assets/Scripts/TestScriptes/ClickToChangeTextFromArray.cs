using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ClickToChangeTextFromArray : MonoBehaviour
{
    public TextMeshProUGUI displayText; // 你的文本UI对象
    public string[] textOptions ;

    int index = 0 ; // 当前显示的文字索引

    void Start()
    {
        // 初始化显示第一个文字
        displayText.text = textOptions[0];
    }

    private void OnMouseDown()
    {
        // 检查点击的对象是否是UI图片
        
            // 切换文字
            SwitchText();
    }

    // 切换文字的方法
    void SwitchText()
    {
        // 显示下一个文字
        index = index+1;
        if (textOptions.Length > 0){
        index = index%(textOptions.Length);
        }else{
            Debug.LogError(textOptions.Length);
        }
        string newText = textOptions[index];
        displayText.text = newText;
    }
}
