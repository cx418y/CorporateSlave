using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Plot1Controller : MonoBehaviour
{   
    //如果没到结尾 展示下一句 如果到了结尾 直接关闭
    public GameObject dialog;
    public TextMeshProUGUI RoleText;
    public TextMeshProUGUI DialogText;
    public int index = 0;
    public int maxIndex;
    void OnMouseDown()
    {
        // 检查物体标签是否为PlotButton
        if (gameObject.CompareTag("PlotButton"))
        {
            //加载场景
            if(index <= maxIndex-1){
                RoleText.text = MainStoryController.Instance.plot1[index,0];
                DialogText.text = MainStoryController.Instance.plot1[index,1];
                index++;
            }else{
                dialog.SetActive(false);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxIndex = MainStoryController.Instance.plot1.Length/2;
        RoleText.text = MainStoryController.Instance.plot1[index,0];
        DialogText.text = MainStoryController.Instance.plot1[index,1];
        index++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
