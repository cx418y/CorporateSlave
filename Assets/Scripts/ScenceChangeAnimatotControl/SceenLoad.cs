using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceenLoad : MonoBehaviour
{
    public Animator animator;
    public GameObject image;
    public GameObject evenObj;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        GameObject.DontDestroyOnLoad(evenObj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerable LoadScence(string scenceName) {
        animator.SetBool("Fadein",true);
        animator.SetBool("Fadeout",false);
        yield return new WaitForSeconds(1F);
       AsyncOperation async= SceneManager.LoadSceneAsync(scenceName);
        async.completed += OnLoadedScene;
   
    }

    private void OnLoadedScene(AsyncOperation operation)
    {
        animator.SetBool("Fadein", false);
        animator.SetBool("Fadeout", true);
    }
}
