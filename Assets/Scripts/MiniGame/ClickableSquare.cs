using UnityEngine;

public class ClickableSquare : MonoBehaviour
{
    // 定义一个颜色数组，包含红、黄、蓝、绿、白五种颜色
    private Color[] colors = { Color.red, Color.yellow, Color.blue, Color.green, Color.white };
    // 定义一个目标颜色数组，与每个方格对应
    public Color[] targetColors = {Color.red ,Color.yellow,Color.blue};

    // 当前颜色索引
    private int currentColorIndex = 0;

    // 当方格被点击时调用
    private void OnMouseDown()
    {
        // 检查鼠标左键是否被点击
        if (Input.GetMouseButtonDown(0))
        {
            // 更改方格的颜色为颜色数组中的下一个颜色
            ChangeColor();
            // 检查是否所有方格都为目标色
            CheckWinCondition();
        }
    }

    // 更改方格颜色的方法
    private void ChangeColor()
    {
        // 获取方格的SpriteRenderer组件
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        // 设置方格的颜色为颜色数组中的下一个颜色
        spriteRenderer.color = colors[currentColorIndex];

        // 增加当前颜色索引以便于下次切换颜色
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
    }

    // 检查是否所有方格都为目标色的方法
    private void CheckWinCondition()
    {
        // 获取场景中所有带有 "ClickableSquare" 标签的方格对象
        GameObject[] gameSquares = GameObject.FindGameObjectsWithTag("GameSquare");

        // // 遍历所有方格对象
        // int i = 0;
        // foreach ( GameObject gameSquare in gameSquares)
        // {   //读取该物体上的颜色进行比较
        //     SpriteRenderer spriteRenderer = gameSquare.GetComponent<SpriteRenderer>();
        //     if (spriteRenderer.color != targetColors[i])
        //     {
        //         Debug.Log(spriteRenderer.color+"try");
        //         Debug.Log(targetColors[i]);
        //     return;
        //     }
        //     // 在此可以对每个方格对象进行处理
        //     i++;
        // }
        // Debug.Log("win");

        /*
        需要注意的是 获取GameSquare的顺序是从Hierarchy中从下至上
        */
        int i=gameSquares.Length-1;
        foreach(GameObject gameSquare in gameSquares)
        {
            Debug.Log("正在检测的GameObject Name为: " + gameSquare.name+"共有三个"+gameSquares.Length);
            SpriteRenderer spriteRenderer = gameSquare.GetComponent<SpriteRenderer>();
            if (spriteRenderer.color != targetColors[i])
            {
                Debug.Log(spriteRenderer.color+"try");
                Debug.Log(targetColors[i]);
                Debug.Log(gameSquare.name+"与目标"+i+"匹配失败");
            return;
            }else{
                Debug.Log(gameSquare.name+"与目标"+i+"匹配成功");
            }
            // 在此可以对每个方格对象进行处理
            i--;
        }
        Debug.Log("全部成功！！！！");
    }
}
