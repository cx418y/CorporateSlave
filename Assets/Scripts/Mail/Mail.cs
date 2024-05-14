using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mail : MonoBehaviour
{
    public string content= "hhh \n hhhh";
    public int fontSize = 16;


    private void OnMouseDown()
    {
        MailManager.Instance.SetContent(content,fontSize);
        GetComponent<SpriteRenderer>().sprite = MailManager.Instance.sprites[1];
    }
}
