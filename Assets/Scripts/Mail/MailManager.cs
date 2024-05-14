using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailManager : MonoBehaviour
{

    private MailManager() { }
    //私有对象
    private static MailManager instance;
    //公有对象
    public static MailManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MailManager();
            }
            return instance;
        }
    }

    public GameObject[] mailList;
    public GameObject contentText;
    public Sprite[] sprites;

    void Awake()
    {
        // 检查是否已存在单例实例
        if (instance == null)
        {
            // 如果不存在，则将当前实例设置为单例，并标记为不可销毁
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 如果存在其他实例，则销毁当前实例
            Destroy(gameObject);
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

   /* void setContent(string content)
    {
        GetComponent<TextMesh>
    }*/
}
