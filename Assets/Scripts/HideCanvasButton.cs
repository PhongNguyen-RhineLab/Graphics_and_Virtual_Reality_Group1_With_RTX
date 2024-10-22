    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideCanvasButton : MonoBehaviour
{
    public GameObject canvasObject;
    public void HideCanvas()
    {
        
            canvasObject.SetActive(false); // Ẩn canvas
        
    }
}
