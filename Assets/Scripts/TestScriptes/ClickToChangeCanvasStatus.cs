using UnityEngine;

public class ClickToChangeCanvasStatus : MonoBehaviour
{
    public GameObject newsPieceCanvas; // 引用 NewsPiece 的 Canvas
    bool viewable = false;

    private void Start()
    {
        // 确保在 Inspector 视图中将 NewsPiece 的 Canvas 分配给此变量
        if (newsPieceCanvas == null)
        {
            Debug.LogError("NewsPiece Canvas is not assigned!");
        }
    }

    private void OnMouseDown()
    {
        // 点击当前对象时 切换Canvas的状态
        viewable = !viewable;
        newsPieceCanvas.SetActive(viewable);
    }
}
