using UnityEngine;

public class MainStoryController : MonoBehaviour
{
    // 单例实例
    private static MainStoryController instance;
    public static MainStoryController Instance
    {
        get
        {
            // 如果实例为空，则查找场景中是否已存在ScriptManager对象
            if (instance == null)
            {
                instance = FindObjectOfType<MainStoryController>();

                // 如果场景中不存在ScriptManager对象，则创建一个新的空对象并添加ScriptManager组件
                // if (instance == null)
                // {
                //     GameObject obj = new GameObject("MainStoryController");
                //     instance = obj.AddComponent<MainStoryController>();
                // }
            }
            return instance;
        }
    }

    // 剧本内容数组
    public string[] mainStoryLines;
    public int nowMainStoryIndex = 0;

    //不同的标题
    public string[,] mainStoryTitles;
    
    public string[,] mainStoryFeedBacks;

    //需要用一个int数组记录玩家的选择 这个int数组的长度等同于mainStoryLines的长度
    public int[] playerChoiceIndexs;



    // 在Awake方法中加载剧本内容（这里假设剧本内容已经存储在数组中）
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
        // 例如，假设剧本内容存储在这个数组中
        mainStoryLines = new string[]
        {
            "main story 1",
            "main story 2",
            "main story 3",
            "main story 4",
            "main story 5",
            // 添加更多的剧本内容...
        };
        //为每个story添加3个可选的标题
        mainStoryTitles = new string[,]
        {
            {"title1.1","title1.2","title1.3"},
            {"title2.1","title2.2","title2.3"},
            {"title3.1","title3.2","title3.3"},
            {"title4.1","title4.2","title4.3"},
            {"title5.1","title5.2","title5.3"},
        };
        //为每个story添加3个可选的反馈
        mainStoryFeedBacks = new string[,]
        {
            {"feedback1.1","feedback1.2","feedback1.3"},
            {"feedback2.1","feedback2.2","feedback2.3"},
            {"feedback3.1","feedback3.2","feedback3.3"},
            {"feedback4.1","feedback4.2","feedback4.3"},
            {"feedback5.1","feedback5.2","feedback5.3"},
        };
        //初始化玩家的选择 全部为0
        playerChoiceIndexs = new int[mainStoryLines.Length];
    }
}
