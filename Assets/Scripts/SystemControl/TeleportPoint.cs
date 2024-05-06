using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportPoint : MonoBehaviour
{
    public string targetSceneName; // 目标场景的名称

    public void LoadTargetScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
    // Start is called before the first frame update

    void OnMouseDown()
    {
        // 检查物体标签是否为movable
        if (gameObject.CompareTag("TeleportPoint"))
        {
            //加载场景
            LoadTargetScene();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
