using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public GameObject objectA; // 物品A的预制体
    public GameObject objectB;
    public Vector3 spawnPoint; // 生成新物品A的相对位置

    // private bool hasSpawned = false; // 是否已经生成了新的物品A
    private bool isTriggered = false; // 是否已经触发了生成动作


    void OnCollisionEnter2D(Collision2D collision)
    {
        // 当物品A与物品B发生碰撞时，并且还没有生成过新的物品A
        if (collision.gameObject == objectB && !isTriggered)
        {
            // 获取物品A相对位置
            Vector3 relativePosition = transform.InverseTransformPoint(objectA.transform.position);

            // 生成一个新的物品A在指定位置
            GameObject newObjectA = Instantiate(objectA, transform.position + relativePosition, Quaternion.identity);

            // 在这里可以执行其他需要的操作
            Debug.Log("生成新物品A");
            isTriggered = true;

            // 设置标志，表示已经生成了新的物品A
            // hasSpawned = true;
        }

    }
    //  void OnCollisionExit2D(Collision2D collision)
    // {
    //     // 当物品A与物品B的碰撞结束时，重置触发状态
    //     if (collision.gameObject == objectB)
    //     {
    //         isTriggered = true;
    //     }
    // }
}
