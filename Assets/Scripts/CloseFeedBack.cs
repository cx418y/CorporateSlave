using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseFeedBack : MonoBehaviour
{   public GameObject feedBack;

    void OnMouseDown()
    {
        // 检查物体标签是否为FeedBackButton
        if (gameObject.CompareTag("ClicktoSubmit"))
        {
            feedBack.SetActive(false);
        }
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
