using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndToday : MonoBehaviour
{
    //一天结束的条件有哪些？
    //小游戏完成了吗 三个新闻都选好了吗
    //对话结束了吗
    
    public TextMeshProUGUI TipText;
    public GameObject dialogBox;

    public GameObject plot2;
    public GameObject plot3;

    void OnMouseDown()
    {
        // 检查物体标签是否为ClicktoSubmit
        if (gameObject.CompareTag("ClicktoSubmit"))
        {      
            if(MainStoryController.Instance.miniGame && MainStoryController.Instance.work && MainStoryController.Instance.mail)
            {

                if(MainStoryController.Instance.systemDay == 0){
                    plot2.SetActive(true);
                }else if(MainStoryController.Instance.systemDay == 3){
                    plot3.SetActive(true);
                }
                else{
                    EndDay();
                    // SceneManager.LoadScene("MainStory");
                }
                
            }else{
                dialogBox.SetActive(true);
                TipText.text = "请先完成今天的工作！";
            
            }

        }
    }

    public void EndDay(){
        MainStoryController.Instance.nowDay++;
        MainStoryController.Instance.systemDay++;
        MainStoryController.Instance.work = false;
        MainStoryController.Instance.nowOffset = 0;
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
