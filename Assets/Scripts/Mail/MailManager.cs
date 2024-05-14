using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MailManager : MonoBehaviour
{

    private MailManager() { }
    //˽�ж���
    private static MailManager instance;

    public TextMeshProUGUI Text;

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
    int mailCount = 0;

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

    public void SetContent(string content,int size)
    {
        Text.text = content;
        Text.fontSize = size;
    }

    public void AddMail()
    {
        if(mailCount == 0)
        {
            mailList[0].SetActive(true);
        }
        else
        {
            mailList[1].SetActive(true);
        }
        Blinking.Instance.StartBlinking();
    }
}
