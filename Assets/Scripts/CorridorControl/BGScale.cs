using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScale : MonoBehaviour
{
    public Vector2 imageSize = new Vector2(1920, 1080);
    // Start is called before the first frame update
    void Start()
    {
        Scaler();
    }

    // Update is called once per frame
    void Update()
    {
       // Scaler();
    }
    void Scaler() { 
     Vector2  canvasSize=gameObject.GetComponentInParent<Canvas>().GetComponent<RectTransform>().sizeDelta;    
        float screenxyRate=canvasSize.x/canvasSize.y;
        Vector2 bgSize = imageSize;
        float texturexyRate=bgSize.x/bgSize.y;
        RectTransform rt = (RectTransform)transform;
        if (texturexyRate > screenxyRate)
        {
            int newSizeY = Mathf.CeilToInt(canvasSize.y);
            int newSizeX = Mathf.CeilToInt((float)newSizeY/ bgSize.y * bgSize.x);
            rt.sizeDelta = new Vector2(newSizeX, newSizeY);
        }
        else {
            int newVedioSizeX = Mathf.CeilToInt(canvasSize.x);
            int newVedioSizeY = Mathf.CeilToInt((float)newVedioSizeX / bgSize.x * bgSize.y);
            rt.sizeDelta = new Vector2(newVedioSizeX,newVedioSizeY);

        }
    }
}
