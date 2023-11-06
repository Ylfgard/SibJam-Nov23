using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GlobalController : MonoBehaviour
{
    public BoardZoom BoardCntrl;
    public GameObject DefaultCursor;
    // Метод, вызываемый при нажатии кнопки мыши на спрайт
    private void Start()
    {
        DefaultCursor = GameObject.Find("DefaultCursor");
    }
   
    private void Update()
    {

        DefaultCursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    // Метод, вызываемый при отпускании кнопки мыши на спрайте


}
