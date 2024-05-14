using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChooseTitle : MonoBehaviour
{
    //需要记录玩家的选择
    public int playerChoiceIndex = 0;
    //0表示未选择

    public TextMeshProUGUI tipsText;

    // Start is called before the first frame update

    //使用碰撞体对玩家的选择进行记录
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.name == "Title1"){
            //通过tiptext告知玩家的选择
            playerChoiceIndex = 1;
            
            tipsText.text = "你选择了标题1，但你可以拖拽到此重新选择";
        }else if(collision.gameObject.name == "Title2"){
            playerChoiceIndex = 2;
            tipsText.text = "你选择了标题2，但你可以拖拽到此重新选择";
        }else if(collision.gameObject.name == "Title3"){
            playerChoiceIndex = 3;
            tipsText.text = "你选择了标题3，但你可以拖拽到此重新选择";
        }else{Debug.Log(collision.gameObject.name);}
        MainStoryController.Instance.playerChoiceIndexs[MainStoryController.Instance.nowMainStoryIndex] = playerChoiceIndex;
    }

    public void recoverTips(){
        tipsText.text = "请把你选择的标题放在这里";
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
