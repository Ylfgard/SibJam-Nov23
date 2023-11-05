using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeObjControl : MonoBehaviour
{
    public GameObject obj1, obj2;
    private void Update()
    {
        if(obj1 && obj2)
        {
            GetComponent<LineRenderer>().SetPosition(0,obj1.transform.position);
            GetComponent<LineRenderer>().SetPosition(1, obj2.transform.position);
            transform.position = Vector2.Lerp(obj1.transform.position, obj2.transform.position, 0.5f);
            
            if(obj1.GetComponent<RopePointControl>().ofBoard == false )
            {

                Destroy(gameObject);
            }
            if(obj2.GetComponent<RopePointControl>().ofBoard == false)
            {
                Destroy(gameObject);
            }
        }
    }
}
