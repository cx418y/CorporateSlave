using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapControl : MonoBehaviour
{
    private GameObject image;
    private Vector3 angles;
    public float rotationSpeed = 0f;
    private Rigidbody rb;
    public float deceleration = 30.0f;
    //是否可以加载到下一场景
    private bool isLoadScence=false;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
         image = GameObject.Find("Image");
 
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
                // 旋转物体
                transform.Rotate(-Vector3.up, rotationSpeed * Time.deltaTime);
                // 减少旋转速度
                rotationSpeed -= deceleration * Time.deltaTime;

            }
            else
            {
               
                // 确保旋转速度不会变成负数
                rotationSpeed = 0;

      
            } 
            if (transform.eulerAngles.y<1)
                {
                    isLoadScence = true;
                }
            if (isLoadScence)
            {

                StartCoroutine(LoadScence());

            }
            else
            {
                Debug.Log("Scene " + "CorridorScence" + " is not in the build settings!");

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
                        // 等待5秒
                        yield return new WaitForSeconds(5f);

            //  StartCoroutine(LoadScence2());
            // animator.SetBool("Fadein", true);
            //      animator.SetBool("Fadeout", false);
            //   
          image.GetComponent<ImageControl>().AnimatorControl();
           
            yield return new WaitForSeconds(1f);
          SceneManager.LoadScene("Corridor");
            //  AsyncOperation async = SceneManager.LoadSceneAsync("CorridorScence");
            //    async.completed += OnLoadedScene;
        }



    }
    private void OnMouseDown()
    {
       rotationSpeed += 5;
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
    //bool IsSceneInBuildSettings(string sceneName)
    //{
    //    foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
    //    {
    //        if (scene.path.IndexOf(sceneName) != -1)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
    //过渡场景切换测试
//    IEnumerator LoadScence2()
//    {
//        animator.SetBool("Fadein", true);
//        animator.SetBool("Fadeout", false);
//        yield return new WaitForSeconds(1F);
//        AsyncOperation async = SceneManager.LoadSceneAsync("CorridorScence");
//        async.completed += OnLoadedScene;

//    }
//    private void OnLoadedScene(AsyncOperation operation)
//    {
//        animator.SetBool("Fadein", false);
//        animator.SetBool("Fadeout", true);
//    }

}
  

