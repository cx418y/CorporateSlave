using UnityEngine;

public class ClickToShowNextMainStory : MonoBehaviour
{
    int index = 0;
    public string[] scriptLines;
    void Start()
    {
        // 通过ScriptManager单例类访问剧本内容数组
        scriptLines = MainStoryController.Instance.mainStoryLines;
    }

    void OnMouseDown(){
        Debug.Log("clicked");
        Debug.Log(scriptLines[index++%scriptLines.Length]);
    }
}
