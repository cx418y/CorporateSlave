using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlockController : MonoBehaviour
{
    // Start is called before the first frame update
    //获取一个gameobject对象
    public GameObject choosednews;
    public TextMeshProUGUI tipsText;

    //编写一个脚本 setChoosednews() 当其他脚本调用他时 可以将choosenews设置为传入的gaemobject
    public void setChoosednews(GameObject news){
        choosednews = news;
        Debug.Log("choosednews is seted as " + news.name);
    }

    //当检测到鼠标点击时，若choosednews不为空，则将choosednews的active设为true
    void OnMouseDown()
    {
        if (choosednews != null)
        {   
            //调整它的位置
            // choosednews.transform.position = choosednews.GetComponent<MoveToNewspaper>().initialPosition;
            // Debug.Log("choosednews is seted in the initial position"+ choosednews.GetComponent<MoveToNewspaper>().initialPosition);
            // choosednews.SetActive(true);
            //将collidable设为true
            // choosednews.SetActive(true);
            choosednews.transform.position = choosednews.GetComponent<MoveToNewspaper>().initialPosition;
            choosednews.GetComponent<MoveToNewspaper>().collidable = true;
            
            
            
            //再将他设为空
            choosednews = null;
            Debug.Log("choosednews is seted as null");
            tipsText.text = "you can drag a news to here";

        }
    }
}
