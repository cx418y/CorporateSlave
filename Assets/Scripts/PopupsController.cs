using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupsController : MonoBehaviour
{
    public TextMeshProUGUI tipsText;

    public void setPopupsText(string text){
        tipsText.text = text;
    }

    void OnMouseDown()
    {
        //关掉弹窗
        gameObject.SetActive(false);
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
