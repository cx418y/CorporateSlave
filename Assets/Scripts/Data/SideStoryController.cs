using UnityEngine;

public class SideStoryController : MonoBehaviour
{
    // 单例实例
    private static SideStoryController instance;
    public static SideStoryController Instance
    {
        get
        {
            // 如果实例为空，则查找场景中是否已存在ScriptManager对象
            if (instance == null)
            {
                instance = FindObjectOfType<SideStoryController>();

                // 如果场景中不存在ScriptManager对象，则创建一个新的空对象并添加ScriptManager组件
                if (instance == null)
                {
                    GameObject obj = new GameObject("SideStoryController");
                    instance = obj.AddComponent<SideStoryController>();
                }
            }
            return instance;
        }
    }

    // 剧本内容数组
    public string[] SideStoryLines;

    //不同的标题
    public string[,] SideStoryTitles;
    
    public string[,] SideStoryFeedBacks;

    // 在Awake方法中加载剧本内容（这里假设剧本内容已经存储在数组中）
    void Awake()
    {
        // 例如，假设剧本内容存储在这个数组中
        SideStoryLines = new string[]
        {
            "Side story 1",
            "Side story 2",
            "Side story 3",
            "Side story 4",
            "Side story 5",
            // 添加更多的剧本内容...
        };
        //为每个story添加3个可选的标题
        SideStoryTitles = new string[,]
        {
            {"title1.1","title1.2","title1.3"},
            {"title2.1","title2.2","title2.3"},
            {"title3.1","title3.2","title3.3"},
            {"title4.1","title4.2","title4.3"},
            {"title5.1","title5.2","title5.3"},
        };
        //为每个story添加3个可选的反馈
        SideStoryFeedBacks = new string[,]
        {
            {"feedback1.1","feedback1.2","feedback1.3"},
            {"feedback2.1","feedback2.2","feedback2.3"},
            {"feedback3.1","feedback3.2","feedback3.3"},
            {"feedback4.1","feedback4.2","feedback4.3"},
            {"feedback5.1","feedback5.2","feedback5.3"},
        };
    }
}
