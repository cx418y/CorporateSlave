using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class plot9Controller : MonoBehaviour
{   
    public GameObject dialog;
    public TextMeshProUGUI RoleText;
    public TextMeshProUGUI DialogText;

    public GameObject plot10;

    //获取名为EndToday的脚本
    public  EndToday endToday;

    public int index = 0;
    public int maxIndex;


    void OnMouseDown()
    {
        // 检查物体标签是否为PlotButton
        if (gameObject.CompareTag("PlotButton"))
        {
            //加载场景
            if(index <= maxIndex-1){
                RoleText.text = MainStoryController.Instance.plot9[index,0];
                DialogText.text = MainStoryController.Instance.plot9[index,1];
                index++;
            }else{
                dialog.SetActive(false);
                endToday.EndDay();
                plot10.SetActive(true);

            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        maxIndex = MainStoryController.Instance.plot9.Length/2;
        RoleText.text = MainStoryController.Instance.plot9[index,0];
        DialogText.text = MainStoryController.Instance.plot9[index,1];
        index++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
