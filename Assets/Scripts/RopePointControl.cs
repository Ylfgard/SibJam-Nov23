using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RopePointControl : MonoBehaviour
{
    public int NumberOfConnections;
    public bool ofBoard;
    public int ID = 1;
    public BoardZoom BoardCntrl;
    public GameObject[] RopeObjs = new GameObject[2];

    private void Start()
    {

        BoardCntrl = GameObject.Find("Board").GetComponent<BoardZoom>();
    }
    private void Update()
    {
        int num = 0;
        for(int i = 0; i < 2; i++)
        {
            if(RopeObjs[i] != null)
            {
                num += 1;
            }
        }
        NumberOfConnections = num;
        ofBoard = BoardCntrl.CheckIfInBoard(transform.position);
        if (!RopeObjs[0].gameObject)
        {
            RopeObjs[0] = null;
        }
        if (!RopeObjs[1].gameObject)
        {
            RopeObjs[1] = null;
        }
        if (RopeObjs[0] == null && RopeObjs[1] != null) 
        {
            RopeObjs[0] = RopeObjs[1];
            RopeObjs[1] = null;
        }
    }
    
}
