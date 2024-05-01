using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickToLoadScene : MonoBehaviour
{
    public string targetSceneName; // 目标场景的名称

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
    //检测鼠标点击事件
    void Update()
{
    if (Input.GetMouseButtonDown(1))
    {
        // 鼠标右键被按下
        Debug.Log("Mouse right button clicked!");
        //加载场景
        LoadTargetScene();
        //还需要解决一个问题 加载了场景需要传递参数 主要传递是主线/支线的第几条
        MainStoryController.Instance.nowMainStoryIndex = 3;
        Debug.Log(MainStoryController.Instance.nowMainStoryIndex);
    }
}

}
