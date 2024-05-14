using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SubmitTitle : MonoBehaviour
{
    // Start is called before the first frame update

    //获取场景中名为ChooseTitle的脚本 并获取他的playerChoiceIndex
    public ChooseTitle chooseTitle;
    public ClickToShowAStory clickToShowAStory;
    public int indexToSubmit;

    //加入弹窗
    public GameObject dialogBox;
    //获取文字组件
    public TextMeshProUGUI TipText;

    //设计一个函数 点击到碰撞体时触发
    void OnMouseDown()
    {
        // 检查物体标签是否为TeleportPoint
        if (gameObject.CompareTag("ClicktoSubmit"))
        {
            indexToSubmit = chooseTitle.playerChoiceIndex;
            if(indexToSubmit == 0){
                dialogBox.SetActive(true);
                TipText.text = "请先选择一个标题";
            }else{
                MainStoryController.Instance.playerChoiceIndexs[clickToShowAStory.myindex] = indexToSubmit;
                Debug.Log(MainStoryController.Instance.playerChoiceIndexs[0]);
                Debug.Log(MainStoryController.Instance.playerChoiceIndexs[1]);
                Debug.Log(MainStoryController.Instance.playerChoiceIndexs[2]);
                SceneManager.LoadScene("ChooseLocation");
            }

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
