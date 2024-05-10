using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveForwardWithButton : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isMoved=true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveWithButtonDown()
    {
        if (isMoved) { 
            StartCoroutine(MoveStart());
        }
        
    }
    IEnumerator MoveStart() {
        isMoved = false;
        float timer = 10f;
        while (timer>0)
        {
 float distance = moveSpeed * Time.deltaTime;
       transform.Translate(Vector3.forward * distance,Space.World);
        yield return new WaitForSeconds(0.05f);
            timer -= 0.05f;
        }
        StartCoroutine(LoadScence());
   
    }
    IEnumerator LoadScence()
    {


        // 等待5秒
        yield return new WaitForSeconds(1f);

        // 5秒后继续执行以下代码
        SceneManager.LoadScene("ClassScence");
    }
}
