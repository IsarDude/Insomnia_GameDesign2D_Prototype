using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoverShapeChanger : MonoBehaviour
{
    public GameObject mouseOverObject;
    
    void Start()
    {

    }
    void OnMouseOver()
    {
        mouseOverObject.SetActive(true);
    }

    void OnMouseExit()
    {
        mouseOverObject.SetActive(false); 
    }
}
