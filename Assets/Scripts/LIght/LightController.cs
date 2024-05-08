using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public TextMeshProUGUI Text;
    private Light mainLight;
    public Color noonColor=new Color(255,156,6,255);
    public Color nightColor = new Color(37,37,37,255);
    private bool isNoonTime;
    private bool isNightTime;
    // Start is called before the first frame update
    void Start()
    {
      // nightColor =  Color(37, 37, 37, 255);
       //  noonColor = Color(255, 156, 6, 255);
        mainLight = GetComponent<Light>();
        isNoonTime = false;
         isNightTime = true;
        //StartCoroutine(TimeToNoon(10));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (!isNoonTime)
        {
            StartCoroutine(TimeToNoon(10));
           
            isNoonTime = true;
        }
        if (!isNightTime)
        {
            StartCoroutine(TimeToNight(10));
           
            isNightTime = true;
        }

    }
    private IEnumerator TimeToNoon(float TimeCount)
    { float lightChange=0f;
        float currentTime = 8f;
        do
        { 
            if (currentTime%1==0)
            {
                Text.text = "ÉÏÎç"+currentTime;
            }
            yield return new WaitForSeconds(1f);
            lightChange += 0.01f;
            mainLight.color = Color.Lerp(mainLight.color, noonColor, lightChange);  
            TimeCount -= 1f;

            currentTime += 0.5f;
            if (currentTime>12f)
            {
                currentTime = 12f;
            }

        } while (TimeCount > 0);
        
       isNightTime=false;

        
    }
    private IEnumerator TimeToNight(float TimeCount)
    {
        float currentTime = 14f;
        float lightChange = 0f;
        do
        {
            if (currentTime % 1 == 0)
            {
                Text.text = "ÏÂÎç" + currentTime;
            }
            yield return new WaitForSeconds(1f);
            lightChange += 0.1f;
            mainLight.color = Color.Lerp(mainLight.color, nightColor, lightChange);
            TimeCount -= 1f;
            currentTime += 0.5f;
            if (currentTime > 18f)
            {
                currentTime = 18f;
            }

        } while (TimeCount > 0);

    }
}
