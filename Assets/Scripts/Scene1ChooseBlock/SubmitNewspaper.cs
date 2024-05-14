using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SubmitNewspaper : MonoBehaviour
{

    //在此处 需要检查当天的三个新闻 是否选好了标题和排版
    //获取当前天数
    public int today ;
    //那么需要检查的有3*today
    public int[] indexToSubmit;

    public TextMeshProUGUI TipText;
    public GameObject dialogBox;

    // Start is called before the first frame update
     void Awake()
    {
        // 如果你知道需要多少个元素，可以在这里初始化
        indexToSubmit = new int[3];
    }
    void Start()
    {
        
        indexToSubmit[0] = MainStoryController.Instance.nowDay*3;
        indexToSubmit[1] = MainStoryController.Instance.nowDay*3+1;
        indexToSubmit[2] = MainStoryController.Instance.nowDay*3+2;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        // 检查物体标签是否为ClicktoSubmit
        if (gameObject.CompareTag("ClicktoSubmit"))
        {
            //首先需要判断是否有未选择标题的新闻
            if(MainStoryController.Instance.playerChoiceIndexs[indexToSubmit[0]] == 0 )
            {
                dialogBox.SetActive(true);
                TipText.text = "第一个新闻未选择标题";
                return;
            }
            if(MainStoryController.Instance.playerChoiceIndexs[indexToSubmit[1]] == 0 )
            {
                dialogBox.SetActive(true);
                TipText.text = "第二个新闻未选择标题";
                return;
            }
            if(MainStoryController.Instance.playerChoiceIndexs[indexToSubmit[2]] == 0 )
            {

                dialogBox.SetActive(true);
                TipText.text = "第三个新闻未选择标题";
                return;
            }

            //其次检查是否有未排版的新闻
            if(MainStoryController.Instance.playerChoiceBlockIndexs[indexToSubmit[0]] == 0 )
            {
                dialogBox.SetActive(true);
                TipText.text = "第一个新闻未排版";
                return;
            }
            
            if(MainStoryController.Instance.playerChoiceBlockIndexs[indexToSubmit[1]] == 0 )
            {
                dialogBox.SetActive(true);
                TipText.text = "第二个新闻未排版";
                return;
            }

            if(MainStoryController.Instance.playerChoiceBlockIndexs[indexToSubmit[2]] == 0 )
            {
                dialogBox.SetActive(true);
                TipText.text = "第三个新闻未排版";
                return;
            }

            //如果都选择了标题和排版 则跳转到下一个场景
            SceneManager.LoadScene("Windows");

        }
    }
}
