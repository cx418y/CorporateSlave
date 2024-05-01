using UnityEngine;

public class DisappearOnClick : MonoBehaviour
{
    // 鼠标点击检测
    private void Update()
    {
        // 如果鼠标左键被点击
        if (Input.GetMouseButtonDown(0))
        {
            // 从屏幕坐标转换为世界坐标
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 检测点击位置是否在物品上
            Collider2D hitCollider = Physics2D.OverlapPoint(clickPosition);

            // 如果点击在物品上
            if (hitCollider != null && hitCollider.gameObject == gameObject)
            {
                // 调用消失函数
                Disappear();
            }
        }
    }

    // 让物品消失
    private void Disappear()
    {
        Destroy(gameObject);
        // 销毁游戏对象
    }

    //这是一个复制一个新物品的函数
    
}
