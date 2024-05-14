using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndToday : MonoBehaviour
{
    //一天结束的条件有哪些？
    //小游戏完成了吗 三个新闻都选好了吗
    //对话结束了吗
    public bool minigame = false;



    void OnMouseDown()
    {
        // 检查物体标签是否为ClicktoSubmit
        if (gameObject.CompareTag("ClicktoSubmit"))
        {}
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
