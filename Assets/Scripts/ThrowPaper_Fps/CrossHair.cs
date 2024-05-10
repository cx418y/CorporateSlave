using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [Header("׼�ǵĳ���")]
    public float width;
    [Header("׼�ǵĸ߶�")]
    public float height;
    [Header("���£����ң�����׼��֮��ľ���")]
    public float distance;
    [Header("׼�Ǳ���ͼ")]
    public Texture2D crosshairTexture;

    private GUIStyle lineStyle;     //  GUI�Զ������
    private Texture tex;            //  ׼�Ǳ�����������

    private void Start()
    {
        lineStyle = new GUIStyle();                         //  ��Ϸ��ʼʵ��������ͼ
        lineStyle.normal.background = crosshairTexture;     //  ������ͼĬ�ϱ�����Ϊ׼�Ǳ���
    }

    private void OnGUI()
    {
        //  ��׼��
        GUI.Box(new Rect(Screen.width / 2 - distance / 2 - width, Screen.height / 2 - height / 2, width, height), tex, lineStyle);
        //  ��׼��
        GUI.Box(new Rect(Screen.width / 2 + distance / 2, Screen.height / 2 - height / 2, width, height), tex, lineStyle);
        //  ��׼��
        GUI.Box(new Rect(Screen.width / 2 - height / 2, Screen.height / 2 - distance / 2 - width, height, width), tex, lineStyle);
        //  ��׼��
        GUI.Box(new Rect(Screen.width / 2 - height / 2, Screen.height / 2 + distance / 2, height, width), tex, lineStyle);
    }
}
