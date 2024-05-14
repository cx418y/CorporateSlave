using UnityEngine;
using UnityEngine.UI;

public class NumberPuzzle : MonoBehaviour
{

    //˽�й��캯��
    private NumberPuzzle() { }
    //˽�ж���
    private static NumberPuzzle instance;
    //���ж���
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
    
    public int gridSize = 4; // ����ߴ�
    public Text winText; // ʤ���ı�

    private int[,] puzzleGrid; // ���ֻ��ݵ�����
    private GameObject[,] CeilItems; // ����Ԫ��Ԥ����
    private int emptyTileX; // �հ׷���� x ����
    private int emptyTileY; // �հ׷���� y ����


    void Awake()
    {
        // ����Ƿ��Ѵ��ڵ���ʵ��
        if (instance == null)
        {
            // ��������ڣ��򽫵�ǰʵ������Ϊ�����������Ϊ��������
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // �����������ʵ���������ٵ�ǰʵ��
            Destroy(gameObject);
        }
        InitializePuzzle();

    }

    void Start()
    {
        instance = Instance;
        // ��ʼ�����ֻ��ݵ�
        
        // Debug.Log(transform.GetChildCount());
        // ��������ͼ
        // CreateNumberGrid();
    }

    void InitializePuzzle()
    {
        // ��ʼ�����ֻ��ݵ�����
        puzzleGrid = new int[gridSize, gridSize];
        CeilItems = new GameObject[gridSize, gridSize];
        int number = 0;

        // �������
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

        // �������һ������Ϊ�հ�
        emptyTileX = gridSize - 1;
        emptyTileY = gridSize - 1;
        puzzleGrid[emptyTileX, emptyTileY] = 0;

        // ��������˳��
        // ShufflePuzzle();
    }

    void ShufflePuzzle()
    {
        // �����������λ��
        for (int i = 0; i < 1000; i++)
        {
            int randomX = Random.Range(0, gridSize);
            int randomY = Random.Range(0, gridSize);
            MoveTile(randomX, randomY, true);
        }
    }

    /*void CreateNumberGrid()
    {
        // ��������Ԫ��
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                *//*// ʵ��������Ԫ��Ԥ����
                GameObject cell = Instantiate(CeilItems, transform);
                Button button = cell.GetComponent<Button>();

                // ���ð�ť�ĵ���¼�
                int posX = x;
                int posY = y;*//*
                // button.onClick.AddListener(() => MoveTile(posX, posY));
                CeilItems[x * gridSize + y].GetComponent<BoxCollider2D>().onMouseDown.AddListener(() => MoveTile(posX, posY));
                // ���õ�Ԫ����ı�����
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
        // ���Ŀ��λ���Ƿ�Ϊ�հ׷��������λ��
        if ((Mathf.Abs(x - emptyTileX) == 1 && y == emptyTileY) ||
            (Mathf.Abs(y - emptyTileY) == 1 && x == emptyTileX))
        {
            Debug.Log("can Move");
            // ��������λ��
            int temp = puzzleGrid[x, y];
            puzzleGrid[x, y] = puzzleGrid[emptyTileX, emptyTileY];
            puzzleGrid[emptyTileX, emptyTileY] = temp;

            
            Sprite tempSprite = CeilItems[x, y].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
            CeilItems[x, y].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = CeilItems[emptyTileX, emptyTileY].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite;
            CeilItems[emptyTileX, emptyTileY].transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = tempSprite;


            // ���¿հ׷���λ��
            emptyTileX = x;
            emptyTileY = y;

            // ����������ʾ
            // UpdateNumberGrid();

            // ����Ƿ��ʤ
            if (!isInit)
            {
                CheckWinCondition();
            }
        }
    }

   /* void UpdateNumberGrid()
    {
        // ����������ʾ
        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                // ���Ҷ�Ӧ������Ԫ��
                Transform cell = transform.GetChild(y * gridSize + x);
               

                // ���µ�Ԫ����ı�����
                Text cellText = cell.GetComponentInChildren<Text>();
                cellText.text = puzzleGrid[x, y].ToString();
            }
        }
    }*/

    void CheckWinCondition()
    {
        // ����Ƿ�ﵽʤ������
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
        // ����ﵽʤ������������ʾʤ���ı�
        if (win)
        {
           Debug.Log("��ϲ�㣬��Ӯ�ˣ�");
        }
    }
}
