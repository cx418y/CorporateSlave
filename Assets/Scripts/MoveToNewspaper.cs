using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNewspaper : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isDragging = false; // 标记是否正在拖拽
    private Vector3 offset; // 鼠标与物体位置的偏移量
    private string movableTag = "movable"; // 可移动物体的标签

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
                
                //打印自己的名字和碰撞物体的名字
                Debug.Log(gameObject.name + " is in  " + collision.gameObject.name);
                // 将自己的active设为false
                gameObject.SetActive(false);
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

