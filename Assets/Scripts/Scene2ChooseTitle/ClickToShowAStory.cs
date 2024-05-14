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
    
    public int offset = 0;
    public int myindex = 0;
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


    void SplitArray(string[,] originalArray, out string[] firstColumn, out string[,] remainingColumns)
    {
        int rows = originalArray.GetLength(0);
        int cols = originalArray.GetLength(1);

        // 初始化新的数组
        firstColumn = new string[rows];
        remainingColumns = new string[rows, cols - 1];

        // 填充新的数组
        for (int i = 0; i < rows; i++)
        {
            firstColumn[i] = originalArray[i, 0];
            for (int j = 1; j < cols; j++)
            {
                remainingColumns[i, j - 1] = originalArray[i, j];
            }
        }
    }
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
        //获取第一列的内容
        //mainStoryLines = MainStoryController.Instance.mainStoryTitles;
        //mainStoryTitles = MainStoryController.Instance.mainStoryTitles;
        //mainStoryFeedBacks = MainStoryController.Instance.mainStoryFeedBacks;
        SplitArray(MainStoryController.Instance.mainStoryTitles, out mainStoryLines, out mainStoryTitles);
        //打印mainStoryLines和mainStoryTitles
        offset = MainStoryController.Instance.nowOffset;
        myindex = MainStoryController.Instance.nowDay*3+offset;
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
        storyText.text = mainStoryLines[myindex];
        title1Text.text = mainStoryTitles[myindex,0];
        title2Text.text = mainStoryTitles[myindex,1];
        title3Text.text = mainStoryTitles[myindex,2];
        //显示
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
