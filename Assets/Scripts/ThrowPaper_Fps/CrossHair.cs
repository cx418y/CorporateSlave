using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [Header("准星的长度")]
    public float width;
    [Header("准星的高度")]
    public float height;
    [Header("上下（左右）两条准星之间的距离")]
    public float distance;
    [Header("准星背景图")]
    public Texture2D crosshairTexture;

    private GUIStyle lineStyle;     //  GUI自定义参数
    private Texture tex;            //  准星背景辅助参数

    private void Start()
    {
        lineStyle = new GUIStyle();                         //  游戏开始实例化背景图
        lineStyle.normal.background = crosshairTexture;     //  将背景图默认背景设为准星背景
    }

    private void OnGUI()
    {
        //  左准星
        GUI.Box(new Rect(Screen.width / 2 - distance / 2 - width, Screen.height / 2 - height / 2, width, height), tex, lineStyle);
        //  右准星
        GUI.Box(new Rect(Screen.width / 2 + distance / 2, Screen.height / 2 - height / 2, width, height), tex, lineStyle);
        //  上准星
        GUI.Box(new Rect(Screen.width / 2 - height / 2, Screen.height / 2 - distance / 2 - width, height, width), tex, lineStyle);
        //  下准星
        GUI.Box(new Rect(Screen.width / 2 - height / 2, Screen.height / 2 + distance / 2, height, width), tex, lineStyle);
    }
}
