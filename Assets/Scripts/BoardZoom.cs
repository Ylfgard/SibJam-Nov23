using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardZoom : MonoBehaviour
{
    public bool isZoom = false;
    // �����, ���������� ��� ������� ������ ���� �� ������
   
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // ��������� ������� ����� ������ ����
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if(hit.collider.tag == "Board" || hit.collider.tag == "Picture" || hit.collider.tag == "RopePoint")
            {
                isZoom = true;
            }
            else
            {
                isZoom = false;
            }
            
        }
    }
    public void isZoomFalse()
    {
        isZoom = false;
    }
    

    
    

}
