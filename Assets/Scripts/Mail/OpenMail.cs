using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMail : TeleportPoint
{
    public GameObject whiteMail;
    // Start is called before the first frame update
    void Start()
    {
       // Blinking.Instance.StartBlinking();
    }

    void OnMouseDown()
    {
        // 检查物体标签是否为TeleportPoint
        if (gameObject.CompareTag("TeleportPoint"))
        {
            Blinking.Instance.StopBlinking();
            /*Blinking blinking = whiteMail.GetComponent
                           <Blinking>();
            blinking.StopBlinking();
            blinking.StopAllCoroutines();*/
            //加载场景
            LoadTargetScene();
        }

    }
}
