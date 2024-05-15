using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FeedBackController : MonoBehaviour
{
    public int myoffset;

    public TextMeshProUGUI Text1;
    public TextMeshProUGUI Text2;
    public TextMeshProUGUI Text3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MainStoryController.Instance.systemDay == 0){
            Text1.text = "还没有已完成的工作噢！";
            Text2.text = "0";
            Text3.text = "0";
        }else{
            Text1.text = MainStoryController.Instance.mainStoryTitles[ (MainStoryController.Instance.nowDay-1)*3+myoffset,MainStoryController.Instance.playerChoiceIndexs[(MainStoryController.Instance.nowDay-1)*3]];
            Text2.text = MainStoryController.Instance.feedback1[(MainStoryController.Instance.nowDay-1)*3+myoffset];
            Text3.text = MainStoryController.Instance.feedback2[(MainStoryController.Instance.nowDay-1)*3+myoffset];
        }
    }
}
