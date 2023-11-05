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

    private void Start()
    {
        BoardCntrl = GameObject.Find("Board").GetComponent<BoardZoom>();
    }
    private void Update()
    {
        ofBoard = BoardCntrl.CheckIfInBoard(transform.position);
    }
}
