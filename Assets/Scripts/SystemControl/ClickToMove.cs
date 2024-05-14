using UnityEngine;

public class ClickAndDrag : MonoBehaviour
{
    private bool isDragging = false; // 标记是否正在拖拽
    private Vector3 offset; // 鼠标与物体位置的偏移量
    private string movableTag = "movable"; // 可移动物体的标签

    //记录初始位置
    public Vector3 initialPosition;


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
        transform.position = initialPosition;

    }

    void Start (){
        //记录初始位置
        initialPosition = transform.position;
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
