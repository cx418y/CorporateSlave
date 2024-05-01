using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ClickToShowAStory : MonoBehaviour
{
    //控制新闻的显示
    public GameObject story;
    public GameObject title1;
    public GameObject title2;
    public GameObject title3;// Start is called before the first frame update
    
    //读取并修改其中的文本内容
    public TextMeshProUGUI storyText;
    public TextMeshProUGUI title1Text;
    public TextMeshProUGUI title2Text;
    public TextMeshProUGUI title3Text;

    private Vector3 title1Position;
    private Vector3 title2Position;
    private Vector3 title3Position;


    //存储剧本内容
    public string[] mainStoryLines;
    public string[,] mainStoryTitles;

    public string[,] mainStoryFeedBacks;

    //记录当前加载的剧本索引
    // public int mainStoryIndex = 0;
    void Start()
    {   
        Debug.Log(MainStoryController.Instance.nowMainStoryIndex);
        //先将上述三个object都关闭
        story.SetActive(false);
        title1.SetActive(false);
        title2.SetActive(false);
        title3.SetActive(false);

        //记录tiele的位置
        // Vector3 storyPosition = story.transform.position;
        title1Position = title1.transform.position;
        title2Position = title2.transform.position;
        title3Position = title3.transform.position;
        // 通过ScriptManager单例类访问剧本内容数组
        mainStoryLines = MainStoryController.Instance.mainStoryLines;
        mainStoryTitles = MainStoryController.Instance.mainStoryTitles;
        mainStoryFeedBacks = MainStoryController.Instance.mainStoryFeedBacks;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //获取故事和标题

    //点击显示故事
    private void OnMouseDown()
    {
        //先附上对应的文字
        // mainStoryIndex = MainStoryController.Instance.nowMainStoryIndex;
        storyText.text = mainStoryLines[MainStoryController.Instance.nowMainStoryIndex];
        title1Text.text = mainStoryTitles[MainStoryController.Instance.nowMainStoryIndex,0];
        title2Text.text = mainStoryTitles[MainStoryController.Instance.nowMainStoryIndex,1];
        title3Text.text = mainStoryTitles[MainStoryController.Instance.nowMainStoryIndex,2];
        //显示
        Debug.Log(MainStoryController.Instance.nowMainStoryIndex);
        story.SetActive(true);
        title1.SetActive(true);
        title2.SetActive(true);
        title3.SetActive(true);
    }

    public void colseStory(){
        story.SetActive(false);
        title1.SetActive(false);
        title2.SetActive(false);
        title3.SetActive(false);
    }

    public void addIndex(){
        MainStoryController.Instance.nowMainStoryIndex ++;
        // mainStoryIndex++;
    }

    public void recoveryTitleLocation(){
        title1.transform.position = title1Position;
        title2.transform.position = title2Position;
        title3.transform.position = title3Position;

    }
}
