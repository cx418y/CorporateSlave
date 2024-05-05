using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeTableController : MonoBehaviour
{
    public TextMeshProUGUI displayText; // 你的文本UI对象
    // Start is called before the first frame update
    public TextMeshProUGUI warningText;

    public TextMeshProUGUI feedbackText;
    int nowday = 1;
    public ChooseTitle chooseTitle;
    public ClickToShowAStory clickToShowAStory;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        // 检查点击的对象是否是UI图片
        
            // 切换文字
            WhetherReadyToNextDay();
    }

    private void WhetherReadyToNextDay(){
        if(chooseTitle.playerChoiceIndex !=0){
            
            ReadyToNextDay();

        }else{
            warningText.text = "You have to choose a title first!";
        }
    }

    private void feedbackControl( int storyIndex , int titleIndex){
        feedbackText.text = clickToShowAStory.mainStoryFeedBacks[storyIndex,titleIndex];
    }
    private void ReadyToNextDay(){
        // nowday++;
        clickToShowAStory.addIndex();
        clickToShowAStory.colseStory();
        clickToShowAStory.recoveryTitleLocation();
        chooseTitle.recoverTips();
        displayText.text = "Day "+nowday++;
        //修改第二天的feedback
        feedbackControl(MainStoryController.Instance.nowMainStoryIndex-1,chooseTitle.playerChoiceIndex-1);
        //重置玩家的选择
        chooseTitle.playerChoiceIndex = 0;
    }
}
