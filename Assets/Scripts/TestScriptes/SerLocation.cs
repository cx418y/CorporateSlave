using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerLocation : MonoBehaviour
{
    public GameObject A;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown(){
        A.transform.position = new Vector3(6.91f,3.0f,0f);
    }
}
