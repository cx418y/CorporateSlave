using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperControl : MonoBehaviour
{
    public GameObject background;
    public GameObject Table;
    public GameObject Table2;
    public GameObject Table3;
    public GameObject Table4;
    public GameObject Table5;

    public GameObject Text1;
    public GameObject Text2;
    public GameObject Text3;
    public GameObject Text4;
    public GameObject Text5;
    public GameObject Text6;
    public GameObject Text7;
    private bool isText1;
    private bool isText2;
    private bool isText3;
    private bool isText4;
    private bool isText5;
    private bool isText6;
    private bool isText7;
    private bool isText8;
    private int count=1;
    // Start is called before the first frame update
    void Start()
    {
        background.SetActive(false);
        isText1 = true;
        isText2 = false;
        isText3 = false;
        isText4 = false;
        isText5 = false; 
        isText6 = false;
        isText7 = false;
        isText8=false;
        Text1.SetActive(false);
        Text2.SetActive(false);
        Text3.SetActive(false);
        Text4.SetActive(false);
        Text5.SetActive(false);
        Text6.SetActive(false);
        Text7.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && count == 1)
        {
            transform.position = Table.transform.position;
            count++;
        }
        else if (Input.GetMouseButtonDown(0) && count == 2)
        {
            transform.position = Table2.transform.position;
            count++;

        }
        else if (Input.GetMouseButtonDown(0) && count == 3)
        {
            transform.position = Table3.transform.position;
            count++;
        }
        else if (Input.GetMouseButtonDown(0) && count == 4)
        {
            transform.position = Table4.transform.position;
            count++;
        }
        else if (Input.GetMouseButtonDown(0) && count == 5)
        {
            transform.position = Table5.transform.position;
            count++;
        }
        else if (count>5)
       
        {
            Debug.Log(isText2);
            if (isText1)
            {
                background.SetActive(true);
                StartCoroutine(Wait(Text1));
              
            }
            else if (isText2)
            {
                StartCoroutine(Wait2(Text2));
             
            }
            else if (isText3)
            {
                StartCoroutine(Wait3(Text3));
             
            }
            else if (isText4)
            {
                StartCoroutine(Wait4(Text4));
              
            }
            else if (isText5)
            {
                StartCoroutine(Wait5(Text5));
         
            }else if (isText6)
            {
                StartCoroutine(Wait6(Text6));
           
            }else if (isText7)
            {
                StartCoroutine(Wait7(Text7));
             

            }

        }

    }
    IEnumerator Wait(GameObject gameObject) {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        isText1 = false;
     isText2=true; 
       

    }
    IEnumerator Wait2(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        isText2 = false;
        isText3 = true;
    }
    IEnumerator Wait3(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        isText3 = false;
        isText4 = true;
    }
    IEnumerator Wait4(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        isText4 = false;
        isText5 = true;


    }
    IEnumerator Wait5(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        isText5 = false;
        isText6 = true;


    }
    IEnumerator Wait6(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        isText6 = false;
        isText7 = true;


    }
    IEnumerator Wait7(GameObject gameObject)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        gameObject.SetActive(false);
        isText7 = false;
        


    }
}
