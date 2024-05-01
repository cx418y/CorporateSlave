using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class DayList {
    public List<Day> list = new List<Day>();
}


public class dataSave : MonoBehaviour
{
    public TextMeshProUGUI Text;
    int currentDay=1;
    public Day day;
    public int number=1;
    public   DayList list = new DayList();
   // public List<Day>dayList=new List<Day>();
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //��ʼ����Ϸ
  public  void StartData() { 
    day = new Day();
        day.numberDay = number;
        day.currentDay = "��"+day.numberDay +"��";
      //  Debug.Log(day.numberDay+day.currentDay);
        list.list.Add(day);
       // Debug.Log(list.list[0].currentDay);
          string json = JsonUtility.ToJson(list);
       
        Debug.Log(json);
        if (!File.Exists(Application.streamingAssetsPath + "/dataList.json"))
        {
           string filepath = Application.streamingAssetsPath + "/dataList.json";
        using (StreamWriter writer = new StreamWriter(filepath))
        {
            writer.WriteLine(json);
            writer.Close();
            writer.Dispose();
        } 
        }
        
    }
    //�������
   public void SaveData()
    {
        string filepath = Application.streamingAssetsPath + "/dataList.json";
        if (File.Exists(filepath))
        {
            day = new Day();
            int current = currentDay;
            current++;
            day.numberDay = current;
            day.currentDay = "��" + day.numberDay + "��";
            list.list.Add(day);
            string json = JsonUtility.ToJson(list);
            //Debug.Log(json);
          
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine(json);
                writer.Close();
                writer.Dispose();
            }
        }
    }
    //��ȡ����
  public  void ReadData()
    {
        string nowDay=null;
        string json;
        string filepath = Application.streamingAssetsPath + "/dataList.json";
        if (File.Exists(filepath))
        {
            using (StreamReader writer = new StreamReader(filepath))
            {
                json = writer.ReadToEnd();
                writer.Close();
                writer.Dispose();
            }
            list = JsonUtility.FromJson<DayList>(json);
            foreach (Day day in list.list)
            {
              //  Debug.Log(day.currentDay);
                currentDay = day.numberDay;
                nowDay = day.currentDay;
               // Debug.Log(nowDay);
            }
            if (nowDay != null)
            {
                Text.text = nowDay;
            }
        }
        else
        {
            Text.text ="��1��";
        }
    } 
    public void RemoveData() 
    {
        if (File.Exists(Application.streamingAssetsPath + "/dataList.json"))
        {
            File.Delete(Application.streamingAssetsPath + "/dataList.json");
        }
    }
 
}
