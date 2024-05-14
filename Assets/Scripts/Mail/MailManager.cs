using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailManager : MonoBehaviour
{

    private MailManager() { }
    //˽�ж���
    private static MailManager instance;
    //���ж���
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
        // ����Ƿ��Ѵ��ڵ���ʵ��
        if (instance == null)
        {
            // ��������ڣ��򽫵�ǰʵ������Ϊ�����������Ϊ��������
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // �����������ʵ���������ٵ�ǰʵ��
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
