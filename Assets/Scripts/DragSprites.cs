using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSprites : MonoBehaviour
{
    public bool isDragging = false;
    private Vector3 offset;

    public BoardZoom BoardCntrl;
    private void Update()
    {
        if (BoardCntrl.isZoom)
        {
            GetComponent<Collider2D>().enabled = true;
            if (Input.GetMouseButtonDown(0) )
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    offset = transform.position - GetMouseWorldPosition();
                }
            }
            if (isDragging)
            {
                transform.position = GetMouseWorldPosition() + offset;
            }
            if (Input.GetMouseButtonUp(0))
            {

                isDragging = false;
            }

        }

        else
            GetComponent<Collider2D>().enabled = false;
    }
    private void Start()
    {
        BoardCntrl = GameObject.Find("Board").GetComponent<BoardZoom>();
    }
    private void OnMouseDown()
    {
        
        if (Input.GetMouseButton(0) && BoardCntrl.isZoom)
        {

            isDragging = true;
            offset = transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
