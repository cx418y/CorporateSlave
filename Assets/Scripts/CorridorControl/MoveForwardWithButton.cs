using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveForwardWithButton : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed = 5f;
    private bool isMoved=true;
    // Start is called before the first frame update
    void Start()
    {
          GameObject image = GameObject.Find("Image");
          animator =image. GetComponent<Animator>();
   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MoveWithButtonDown()
    {
        Debug.Log("walk");
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
        animator.SetBool("Fadein", true);
        animator.SetBool("Fadeout", false);
        yield return new WaitForSeconds(1f);
        StartCoroutine(LoadScence());
   
    }
    IEnumerator LoadScence()
    {


        // �ȴ�5��
        yield return new WaitForSeconds(1f);

        // 5������ִ�����´���
        SceneManager.LoadScene("ClassScence");
    }
}
