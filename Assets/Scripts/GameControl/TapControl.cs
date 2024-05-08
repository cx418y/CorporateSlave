using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapControl : MonoBehaviour
{
    private Vector3 angles;
    public float rotationSpeed = 0f;
    private Rigidbody rb;
    public float deceleration = 30.0f;
    //�Ƿ���Լ��ص���һ����
    private bool isLoadScence=false;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
       // angles = transform.localEulerAngles;
       // angles.y -= 30 * rotationSpeed;
       //transform.localEulerAngles = angles;
        Debug.Log(transform.eulerAngles.y);
        if (transform.eulerAngles.y>1)
        {
            if (rotationSpeed > 0)
            {
                // ��ת����
                transform.Rotate(-Vector3.up, rotationSpeed * Time.deltaTime);
                // ������ת�ٶ�
                rotationSpeed -= deceleration * Time.deltaTime;

            }
            else
            {
               
                // ȷ����ת�ٶȲ����ɸ���
                rotationSpeed = 0;

      
            } 
            if (transform.eulerAngles.y<1)
                {
                    isLoadScence = true;
                }  
            if (isLoadScence)
                { 
                 if (IsSceneInBuildSettings("CorridorScence"))
                {
                    StartCoroutine(LoadScence());
                    
                }
                else
                {
                    Debug.LogError("Scene " + "CorridorScence" + " is not in the build settings!");
                }
                }
       }
       // else if(transform.eulerAngles.y>350)
      //  {
           // rotationSpeed -= deceleration * Time.deltaTime;  
          //  isRotation = false;
      //  }
           IEnumerator LoadScence()
                    {

                        Debug.Log("Wait");
                        // �ȴ�5��
                        yield return new WaitForSeconds(5f);
                        SceneManager.LoadScene("CorridorScence");
                        // 5������ִ�����´���
                    }



    }
    private void OnMouseDown()
    {
       rotationSpeed += 5;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    bool IsSceneInBuildSettings(string sceneName)
    {
        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.path.IndexOf(sceneName) != -1)
            {
                return true;
            }
        }
        return false;
    }
}
  

