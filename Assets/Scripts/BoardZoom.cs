using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardZoom : MonoBehaviour
{
    public GameObject BackButton;
    public Vector2 DefaultPicturePos;
    Vector2 topLeftCorner, bottomRightCorner;
    public bool isZoom = false;
    // Метод, вызываемый при нажатии кнопки мыши на спрайт
    private void Start()
    {
        BackButton.SetActive(false);
        topLeftCorner = GetComponent<BoxCollider2D>().bounds.min;
        bottomRightCorner = GetComponent<BoxCollider2D>().bounds.max;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Обработка отжатия левой кнопки мыши
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            Debug.Log(hit.collider.gameObject);
            if(hit.collider.tag == "Board")
            {
                isZoom = true;

            }
            if(hit.collider.tag == "BackButton")
            {
                isZoom = false;
                BackButton.SetActive(false);
            }

            
        }
        GetComponent<Collider2D>().enabled = !isZoom;
    }
    
    public void SetActiveBack()
    {
        BackButton.SetActive(true);
    }
    public bool CheckIfInBoard(Vector2 position)
    {
        float xMin = Mathf.Min(topLeftCorner.x, bottomRightCorner.x);
        float xMax = Mathf.Max(topLeftCorner.x, bottomRightCorner.x);
        float yMin = Mathf.Min(topLeftCorner.y, bottomRightCorner.y);
        float yMax = Mathf.Max(topLeftCorner.y, bottomRightCorner.y);

        return position.x >= xMin && position.x <= xMax && position.y >= yMin && position.y <= yMax;
    }





}
