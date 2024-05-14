using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TextTime : MonoBehaviour
{
    public TextMeshProUGUI TipText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TipText.text = "第" + MainStoryController.Instance.systemDay + "天";
    }
}
