using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CorridorScenceCameraControl : MonoBehaviour
{
    private Animator animator;
    private bool flag = true;
    private Camera camera;
    public Color toColor;
    private GameObject moveButton;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        moveButton = GameObject.Find("MoveButton");
        moveButton.SetActive(false);
     //   GameObject image = GameObject.Find("Image");
      //  animator =image. GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // if (flag) {
    //        float temp = 0.1f;
    //  this.transform.Rotate(0.5f, 0, 0);
         //GameObject background=   GameObject.Find("background");
    // Image    image=background.GetComponent<Image>();
         //   temp += 0.01f;
            //image.color = Color.Lerp(image.color,toColor,temp);

       // if (transform.eulerAngles.x>45)
       // {
       //         transform.eulerAngles = new Vector3(45,0,0);
        //        flag = false;
      //  }
       // }
    }
    private void FixedUpdate()
    {
        if (flag)
        {
 StartCoroutine(ChangeCameraRotate());
        }
       
        //if (flag)
        //{
        //    float temp = 0.1f;
        //    this.transform.Rotate(0.5f, 0, 0);
        //    GameObject background = GameObject.Find("background");
        //    Image image = background.GetComponent<Image>();
        //    temp += 0.01f;
        //    image.color = Color.Lerp(image.color, toColor, temp);

        //    if (transform.eulerAngles.x > 45)
        //    {
        //        transform.eulerAngles = new Vector3(45, 0, 0);
        //        flag = false;
             
               
              
        //    }
        //}
    }
    IEnumerator ChangeCameraRotate() {
           GameObject background = GameObject.Find("background"); 
        float temp = 0.1f;
        float waitTime = 5f;
        Image image = background.GetComponent<Image>();
        yield return new WaitForSeconds(3f);

        do
        {
          
            yield return new WaitForSeconds(1f);
            temp += 0.005f;
           image.color = Color.Lerp(image.color, toColor, temp);
            waitTime -= 1f;
            this.transform.Rotate(0.5f, 0, 0);
            if (transform.eulerAngles.x > 45)
            {
                transform.eulerAngles = new Vector3(45, 0, 0);
                flag = false;
                moveButton.SetActive(true);
             //  StartCoroutine(LoadScence());
            }
        } while (waitTime>0);
    }
    //IEnumerator LoadScence()
    //{


    //    // 等待5秒
    //    yield return new WaitForSeconds(5f);

    //    // 5秒后继续执行以下代码
    //    SceneManager.LoadScene("ClassScence");
    //}
}
