using UnityEngine;
using UnityEngine.UI;

public class NumberGrid : MonoBehaviour
{
    public GameObject gridCellPrefab; // ����Ԫ��Ԥ����
    public int gridSize = 4; // ����ߴ�

    void Start()
    {
        // ��������ͼ
        CreateNumberGrid();
    }

    void CreateNumberGrid()
    {
        // ���㵥Ԫ��Ŀ�Ⱥ͸߶�
        float cellWidth = GetComponent<RectTransform>().rect.width / gridSize;
        float cellHeight = GetComponent<RectTransform>().rect.height / gridSize;

        // ��������Ԫ��
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                // ���㵥Ԫ���λ��
                Vector3 cellPosition = new Vector3(x * cellWidth + cellWidth / 2, -y * cellHeight - cellHeight / 2, 0f);

                // ������Ԫ����Ϸ�������ø�����
                GameObject cell = Instantiate(gridCellPrefab, transform);
                cell.transform.localPosition = cellPosition;

                // ���õ�Ԫ����ı����ݣ�ʾ��Ϊ����������
                /*Text cellText = cell.GetComponentInChildren<Text>();
                cellText.text = (y * gridSize + x + 1).ToString();*/
                Debug.Log(cellPosition.ToString());
            }
        }
    }
}
