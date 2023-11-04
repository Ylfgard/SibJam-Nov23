using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class RopeControl : MonoBehaviour
{
    public GameObject RopeObjPrefab;
    bool drag = false;
    private bool ropeFlag = false;
    public GameObject[] RopeObjs = new GameObject[100];
    GameObject currentRopeObj,preRopePoint,postRopePoint;
    
    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))  // Обработка отжатия левой кнопки мыши
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            Debug.Log(hit.collider);
            if (hit.collider.GetComponent<RopePointControl>())
            {
                if (hit.collider.GetComponent<RopePointControl>().NumberOfConnections < 2)
                {
                    hit.collider.GetComponent<RopePointControl>().NumberOfConnections += 1;
                    currentRopeObj = Instantiate(RopeObjPrefab, Vector2.zero, Quaternion.identity);
                    currentRopeObj.GetComponent<LineRenderer>().SetPosition(0, hit.collider.transform.position);
                    currentRopeObj.GetComponent<RopeObjControl>().obj1 = hit.collider.gameObject;
                    preRopePoint = hit.collider.gameObject;
                    drag = true;
                    Debug.Log("Begin");
                }
            }
        }
        if (Input.GetMouseButton(0) && drag)
        {
            currentRopeObj.GetComponent<LineRenderer>().SetPosition(1, Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        if (Input.GetMouseButtonUp(0) && drag)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider.GetComponent<RopePointControl>())
            {
                if (hit.collider.GetComponent<RopePointControl>().NumberOfConnections < 2)
                {
                    hit.collider.GetComponent<RopePointControl>().NumberOfConnections += 1;
                    postRopePoint = hit.collider.gameObject;
                    currentRopeObj.GetComponent<LineRenderer>().SetPosition(1, hit.collider.transform.position);
                    currentRopeObj.GetComponent<RopeObjControl>().obj2 = hit.collider.gameObject;
                    drag = false;
                    Debug.Log("End");
                }
            }
            else
            {
                Destroy(currentRopeObj);
            }
        }
    }

    //private void OnMouseUp()
    //{
    //    if (!preRopeCtrl) return;
    //    // Создание луча
    //    Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z-5));

    //    // Настройка параметров луча
    //    float maxDistance = 100f;


    //    RaycastHit hit;

    //    // Проверка столкновения луча с объектом
    //    if (Physics.Raycast(Input.mousePosition,new Vector3(0,0,1), out hit))
    //    {
    //        Debug.Log(hit.collider.name);
    //        if (hit.collider.GetComponent<RopeControl>())
    //        {
    //            postRopeCtrl = hit.collider.gameObject;
    //            lineRenderer.SetPosition(1, hit.collider.transform.position);
    //            hit.collider.GetComponent<RopeControl>().preRopeCtrl = gameObject;
    //            ropeFlag = true;
    //        }
    //        else
    //        {
    //            lineRenderer.SetPosition(0, transform.position);
    //            lineRenderer.SetPosition(1, transform.position);
    //        }
    //    }
    //    else
    //        Debug.Log(123);


    //}
    
}
