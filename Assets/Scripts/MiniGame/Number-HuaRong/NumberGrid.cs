using UnityEngine;
using UnityEngine.UI;

public class NumberGrid : MonoBehaviour
{
    public GameObject gridCellPrefab; // 网格单元格预制体
    public int gridSize = 4; // 网格尺寸

    void Start()
    {
        // 创建数字图
        CreateNumberGrid();
    }

    void CreateNumberGrid()
    {
        // 计算单元格的宽度和高度
        float cellWidth = GetComponent<RectTransform>().rect.width / gridSize;
        float cellHeight = GetComponent<RectTransform>().rect.height / gridSize;

        // 创建网格单元格
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                // 计算单元格的位置
                Vector3 cellPosition = new Vector3(x * cellWidth + cellWidth / 2, -y * cellHeight - cellHeight / 2, 0f);

                // 创建单元格游戏对象并设置父对象
                GameObject cell = Instantiate(gridCellPrefab, transform);
                cell.transform.localPosition = cellPosition;

                // 设置单元格的文本内容（示例为网格索引）
                /*Text cellText = cell.GetComponentInChildren<Text>();
                cellText.text = (y * gridSize + x + 1).ToString();*/
                Debug.Log(cellPosition.ToString());
            }
        }
    }
}
