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
    float durationRot = 3f;
    bool zoom = false;
    bool zooming = false;
    public float zoomScale = 10f;
    Vector2 prePosition;
    Vector2 preScale;
    public bool inList = false;
    private void Start()
    {
        BoardCntrl = GameObject.Find("Board").GetComponent<BoardZoom>();
        RopePoint = transform.GetChild(0).gameObject;
    }

    private void Update()
    {
        
        
            
            if (Input.GetMouseButtonDown(0) && !zoom)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
                if (hit.collider.gameObject == gameObject)
                {
                    isDragging = true;
                    inList = false;
                    offset = transform.position - GetMouseWorldPosition();
                }
            }
            if (isDragging)
            {
                transform.position = GetMouseWorldPosition() + offset;

                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 20), durationRot);
            }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, 0), durationRot);
        }
            if (Input.GetMouseButtonUp(0))
            {

                isDragging = false;
            }
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            if (hit.collider.gameObject == gameObject)
            {
                zoom = !zoom;
                zooming = true;
            }
        }
        
        


        if (Input.GetMouseButtonDown(0) && !zoom)

            Debug.Log(RopePoint.GetComponent<RopePointControl>().ofBoard);
        if (!isDragging && !RopePoint.GetComponent<RopePointControl>().ofBoard && !inList && !zoom)
        {
            returnPicture = true;
        }
        else
            returnPicture = false;
        if(returnPicture)
        {
            transform.position = Vector2.Lerp(transform.position, BoardCntrl.DefaultPicturePos, Time.deltaTime / duration);
            if(Vector2.Distance(transform.position, BoardCntrl.DefaultPicturePos) < 3f || isDragging)
            {
                returnPicture = false;
                inList = true;
                gameObject.SetActive(false);

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
