using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageControl : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AnimatorControl() {
        animator.SetBool("Fadeout", false);
          animator.SetBool("Fadein", true);
         
    }
}
