using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveToNewspaper : MonoBehaviour
{

    //获取一个text对象
    public TextMeshProUGUI tipsText;
    // Start is called before the first frame update
    private bool isDragging = false; // 标记是否正在拖拽
    private Vector3 offset; // 鼠标与物体位置的偏移量
    private string movableTag = "movable"; // 可移动物体的标签

    public bool collidable = true;

    public Vector3 initialPosition;

    //获取一个名为BlockController的脚本
    public BlockController blockController;

    void Start (){
        //记录初始位置
        initialPosition = transform.position;
    }
    void OnMouseDown()
    {
        // 检查物体标签是否为movable
        if (gameObject.CompareTag("movable"))
        {
            isDragging = true;
            offset = gameObject.transform.position - GetMouseWorldPos();
        }else 
        {
            Debug.Log("This object is unmovable!");
            // 在这里添加你想要执行的不可移动代码
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("NewsLocation"))
            {
                if(collidable){
                //修改提示符号
                // 将自己的active设为false
                //从collision中获取他身上的text

                tipsText.text = gameObject.name + " is in  " + collision.gameObject.name +"but you can click to cancel";
                //恢复原位
                transform.position = initialPosition;
                // gameObject.SetActive(false);
                //获取碰撞体身上的blockController脚本
                blockController = collision.gameObject.GetComponent<BlockController>();

                blockController.setChoosednews(gameObject);
                // gameObject.SetActive(false);
                collidable = false;
                }
            }else{
                Debug.Log("This object is not a NewsLocation!");
            }
    }

    void Update()
    {
        if (isDragging)
        {
            // 更新物体位置为鼠标位置
            Vector3 newPos = GetMouseWorldPos() + offset;
            transform.position = newPos;
        }
    }

    // 获取鼠标位置的世界坐标
    public Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = Camera.main.nearClipPlane;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}

