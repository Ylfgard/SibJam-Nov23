using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCintrol : MonoBehaviour
{
    public GameObject Board;
    BoardZoom BoardCntrl;

    public float duration = 2f; // ¬рем€, в течение которого будут измен€тьс€ значени€

    public float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        BoardCntrl = Board.GetComponent<BoardZoom>();
    }

    // Update is called once per frame
    void Update()
    {
        if (BoardCntrl.isZoom == true)
        {
            
            transform.position = Vector3.Lerp(transform.position, Board.transform.position, Time.deltaTime / duration );
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 5.5f, Time.deltaTime / duration);
            if(Camera.main.orthographicSize < 5.6f)
            {
                BoardCntrl.SetActiveBack();
            }
            
        }
        else
        {
            
            transform.position = Vector3.Lerp(transform.position, Vector3.zero, Time.deltaTime / duration );
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, 13.23f, Time.deltaTime / duration);
            
        }
        
        
            
    }
}
