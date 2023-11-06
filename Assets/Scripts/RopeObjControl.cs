using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeObjControl : MonoBehaviour
{
    public GameObject obj1, obj2;
    bool flag = true;
    public Vector3 startRope, endRope;
    public float height = 50f;
    public int resolution = 30;
    public GameObject CrossCursor,DefaultCursor;
    private void Start()
    {
        GetComponent<LineRenderer>().positionCount = resolution + 1;
        CrossCursor = GameObject.Find("CrossCursor");
        DefaultCursor = GameObject.Find("DefaultCursor");
        UpdateLineRenderer();
    }
    private void Update()
    {
        if(obj1 && obj2)
        {
            if (flag)
            {
                flag = false;
                obj1.GetComponent<RopePointControl>().NumberOfConnections += 1;
                obj2.GetComponent<RopePointControl>().NumberOfConnections += 1;
            }
            obj1.GetComponent<RopePointControl>().RopeObjs[obj1.GetComponent<RopePointControl>().NumberOfConnections] = gameObject;
            obj2.GetComponent<RopePointControl>().RopeObjs[obj1.GetComponent<RopePointControl>().NumberOfConnections] = gameObject;
            startRope = obj1.transform.position;
            endRope = obj2.transform.position;
            UpdateLineRenderer();
            transform.position = Vector2.Lerp(obj1.transform.position, obj2.transform.position, 0.5f);
            
            if(obj1.GetComponent<RopePointControl>().ofBoard == false )
            {
                obj1.GetComponent<RopePointControl>().NumberOfConnections -= 1;
                obj2.GetComponent<RopePointControl>().NumberOfConnections -= 1;
                Destroy(gameObject);
            }
            if(obj2.GetComponent<RopePointControl>().ofBoard == false)
            {
                obj1.GetComponent<RopePointControl>().NumberOfConnections -= 1;
                obj2.GetComponent<RopePointControl>().NumberOfConnections -= 1;
                Destroy(gameObject);
            }
            
            if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), GetComponent<LineRenderer>().GetPosition(16))<2)
            {
                CrossCursor.SetActive(true);
                DefaultCursor.SetActive(false);
                CrossCursor.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Debug.Log(Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), GetComponent<LineRenderer>().GetPosition(16)));
                if (Input.GetMouseButtonDown(1))
                {
                    Destroy(gameObject);
                    CrossCursor.SetActive(false);
                    DefaultCursor.SetActive(true);
                }
            }
            else
            {
                DefaultCursor.SetActive(true);
                CrossCursor.SetActive(false);
            }
        }
        UpdateLineRenderer();
    }
    private void UpdateLineRenderer()
    {
        Vector3[] positions = new Vector3[resolution + 1];

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / resolution;
            positions[i] = CalculateParabolicPoint(t);
        }

        GetComponent<LineRenderer>().SetPositions(positions);
    }

    private Vector3 CalculateParabolicPoint(float t)
    {
        Vector3 point = Vector3.Lerp(startRope, endRope, t);
        point.y += Mathf.Sin(t * Mathf.PI) * height;
        return point;
    }
    
}
