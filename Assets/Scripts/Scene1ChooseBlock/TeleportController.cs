using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportController : MonoBehaviour
{
    

    public void LoadTargetScene(string targetSceneName)
    {
        SceneManager.LoadScene(targetSceneName);
    }

    //检测碰撞事件
    void OnCollisionEnter2D(Collision2D collision)
    {
        //如果在碰撞体身上发现了名为MoveToNewspaper的脚本
        if (collision.gameObject.GetComponent<MoveToNewspaper>())
        {
            //加载场景
            //获取脚本上名为sceneName的变量
            MainStoryController.Instance.nowOffset = collision.gameObject.GetComponent<MoveToNewspaper>().myOffset;
            LoadTargetScene(collision.gameObject.GetComponent<MoveToNewspaper>().sceneName);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
