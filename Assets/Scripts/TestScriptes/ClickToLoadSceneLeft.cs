using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToLoadSceneLeft : MonoBehaviour
{
    // Start is called before the first frame update
    public string targetSceneName; // 目标场景的名称

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
    //检测鼠标点击事件
    void Update()
{
    if (Input.GetMouseButtonDown(0))
    {
        //加载场景
        LoadTargetScene();
    }
}
}
