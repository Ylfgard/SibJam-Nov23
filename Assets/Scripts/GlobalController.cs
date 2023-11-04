using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GlobalController : MonoBehaviour
{
    public BoardZoom BoardCntrl;
    // Метод, вызываемый при нажатии кнопки мыши на спрайт
    private void Start()
    {
        GetComponent<Collider2D>().enabled = false;
    }
    private void OnMouseDown()
    {
        if(BoardCntrl.isZoom == true)
        {
            BoardCntrl.isZoomFalse();
            
        }
       
    }
    private void Update()
    {
        if (BoardCntrl.isZoom == true)
        {
            
            GetComponent<Collider2D>().enabled = true;
            BoardCntrl.GetComponent<Collider2D>().enabled = true;
        }
        else
            GetComponent<Collider2D>().enabled = false;
    }

    // Метод, вызываемый при отпускании кнопки мыши на спрайте


}
