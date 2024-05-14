using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilItem : MonoBehaviour
{
    public GameObject Grid;
    public int XIndex;
    public int YIndex;

    private void OnMouseDown()
    {
        NumberPuzzle.Instance.MoveTile(XIndex, YIndex, false);
        Debug.Log("Click x: " + XIndex + "y: " + YIndex);
    }
}
