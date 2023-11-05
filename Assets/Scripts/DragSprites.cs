using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragSprites : MonoBehaviour
{
    public bool isDragging = false;
    
    private Vector3 offset;
    GameObject RopePoint;
    public BoardZoom BoardCntrl;
    public bool returnPicture = false;
    float duration = 0.5f;
    private void Start()
    {
        BoardCntrl = GameObject.Find("Board").GetComponent<BoardZoom>();
        RopePoint = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        
        
            
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




        Debug.Log(RopePoint.GetComponent<RopePointControl>().ofBoard);
        if(!isDragging && !RopePoint.GetComponent<RopePointControl>().ofBoard)
        {
            returnPicture = true;
        }
        if(returnPicture)
        {
            transform.position = Vector2.Lerp(transform.position, BoardCntrl.DefaultPicturePos, Time.deltaTime / duration);
            if(Vector2.Distance(transform.position, BoardCntrl.DefaultPicturePos) < 0.01 || isDragging)
            {
                returnPicture = false;
            }
        }
    }
    
    

    private Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
