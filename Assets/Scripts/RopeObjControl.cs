using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeObjControl : MonoBehaviour
{
    public GameObject obj1, obj2;
    bool flag = true;
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
            GetComponent<LineRenderer>().SetPosition(0,obj1.transform.position );
            GetComponent<LineRenderer>().SetPosition(1, obj2.transform.position );
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
        }
    }
}
