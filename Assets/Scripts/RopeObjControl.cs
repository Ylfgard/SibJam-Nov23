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
        }
    }
}
