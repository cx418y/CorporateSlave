using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickToLoadScene : MonoBehaviour
{
    public string targetSceneName; // 目标场景的名称
    public string teleportPoint;

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }

    void OnMouseDown()
    {
        Debug.Log(gameObject.name+teleportPoint);
        if (gameObject.name == teleportPoint && Input.GetMouseButtonDown(1)) // Right mouse button
        {
            LoadTargetScene();
        }
    }
    

}
