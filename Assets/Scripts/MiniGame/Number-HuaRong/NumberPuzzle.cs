using UnityEngine;
using UnityEngine.UI;

public class NumberPuzzle : MonoBehaviour
{

    //私有构造函数
    private NumberPuzzle() { }
    //私有对象
    private static NumberPuzzle instance;
    //公有对象
    public static NumberPuzzle Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new NumberPuzzle();
            }
            return instance;
        }
    }
    
    public int gridSize = 4; // 网格尺寸
    public Text winText; // 胜利文本

    private int[,] puzzleGrid; // 数字华容道布局
    private GameObject[,] CeilItems; // 网格单元格预制体
    private int emptyTileX; // 空白方块的 x 坐标
    private int emptyTileY; // 空白方块的 y 坐标


    void Awake()
    {
        // 检查是否已存在单例实例
        if (instance == null)
        {
            // 如果不存在，则将当前实例设置为单例，并标记为不可销毁
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 如果存在其他实例，则销毁当前实例
            Destroy(gameObject);
        }
        InitializePuzzle();

    }

    void Start()
    {
        instance = Instance;
        // 初始化数字华容道
        
        // Debug.Log(transform.GetChildCount());
        // 创建数字图
        // CreateNumberGrid();
    }

    void InitializePuzzle()
    {
        // 初始化数字华容道布局
        puzzleGrid = new int[gridSize, gridSize];
        CeilItems = new GameObject[gridSize, gridSize];
        int number = 0;

        // 填充数字
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                puzzleGrid[x, y] = number;
                number++;
                CeilItems[x, y] = transform.GetChild((x * gridSize) + y).gameObject;
                CeilItems[x, y].GetComponent<CeilItem>().XIndex = x;
                CeilItems[x, y].GetComponent<CeilItem>().YIndex = y;
            }
        }

        // 设置最后一个格子为空白
        emptyTileX = gridSize - 1;
        emptyTileY = gridSize - 1;
        puzzleGrid[emptyTileX, emptyTileY] = 0;

        // 打乱数字顺序
        // ShufflePuzzle();
    }

    void ShufflePuzzle()
    {
        // 随机交换数字位置
        for (int i = 0; i < 1000; i++)
        {
            int randomX = Random.Range(0, gridSize);
            int randomY = Random.Range(0, gridSize);
            MoveTile(randomX, randomY, true);
        }
    }

    /*void CreateNumberGrid()
    {
        // 创建网格单元格
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                *//*// 实例化网格单元格预制体
                GameObject cell = Instantiate(CeilItems, transform);
                Button button = cell.GetComponent<Button>();

                // 设置按钮的点击事件
                int posX = x;
                int posY = y;*//*
                // button.onClick.AddListener(() => MoveTile(posX, posY));
                CeilItems[x * gridSize + y].GetComponent<BoxCollider2D>().onMouseDown.AddListener(() => MoveTile(posX, posY));
                // 设置单元格的文本内容
                Text cellText = cell.GetComponentInChildren<Text>();
                cellText.text = puzzleGrid[x, y].ToString();
            }
        }
    }*/

    public void MoveTile(int x, int y, bool isInit)
    {
        Debug.Log("into Move");
        Debug.Log("emptyX: "+emptyTileX);
        Debug.Log("emptyY: " + emptyTileY);
        // 检查目标位置是否为空白方块的相邻位置
        if ((Mathf.Abs(x - emptyTileX) == 1 && y == emptyTileY) ||
            (Mathf.Abs(y - emptyTileY) == 1 && x == emptyTileX))
        {
            Debug.Log("can Move");
            // 交换数字位置
            int temp = puzzleGrid[x, y];
            puzzleGrid[x, y] = puzzleGrid[emptyTileX, emptyTileY];
            puzzleGrid[emptyTileX, emptyTileY] = temp;

            
            Sprite tempSprite = CeilItems[x, y].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
            CeilItems[x, y].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = CeilItems[emptyTileX, emptyTileY].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
            CeilItems[emptyTileX, emptyTileY].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = tempSprite;


            // 更新空白方块位置
            emptyTileX = x;
            emptyTileY = y;

            // 更新网格显示
            // UpdateNumberGrid();

            // 检查是否获胜
            if (!isInit)
            {
                CheckWinCondition();
            }
        }
    }

   /* void UpdateNumberGrid()
    {
        // 更新网格显示
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                // 查找对应的网格单元格
                Transform cell = transform.GetChild(y * gridSize + x);
               

                // 更新单元格的文本内容
                Text cellText = cell.GetComponentInChildren<Text>();
                cellText.text = puzzleGrid[x, y].ToString();
            }
        }
    }*/

    void CheckWinCondition()
    {
        // 检查是否达到胜利条件
        bool win = true;
        int number = 1;
        string arrayString = "";
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                arrayString += puzzleGrid[x, y] + " ";
                if (puzzleGrid[x, y] != number)
                {
                    win = false;
                    
                    // break;
                }

                number++;
            }
            arrayString += "\n";
        }
        Debug.Log(arrayString);
        // 如果达到胜利条件，则显示胜利文本
        if (win)
        {
           Debug.Log("恭喜你，你赢了！");
        }
    }
}
