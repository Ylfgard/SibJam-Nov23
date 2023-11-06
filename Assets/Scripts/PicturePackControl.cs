using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
public class PicturePackControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 StartListPos;
    public List<GameObject> PicturesList;
    public bool ListActive = false;
    public float dx = 0.2f,dy = 1f;
    void Start()
    {
       
        StartListPos = transform.position;
        // Получаем список объектов с заданным тэгом
        PicturesList = GameObject.FindGameObjectsWithTag("Picture").ToList();

        // Выводим информацию о найденных объектах
        
    }

    // Update is called once per frame
    void Update()
    {
        float offsetX = StartListPos.x-4;
        int i = 0;
        
            foreach (GameObject pic in PicturesList)
            {
                if (pic.GetComponent<DragSprites>().inList == true)
                {
                    pic.GetComponent<DragSprites>().returnPicture = false;
                    
                    pic.transform.position = new Vector2(offsetX + i * dx, StartListPos.y+dy);
                    i++;
                    if (ListActive)
                    {
                        pic.SetActive(true);
                    }
                    else
                    {
                        pic.SetActive(false);
                    }
                }

            }
        
    }
    private void OnMouseDown()
    {
        if (!ListActive)
        {
            foreach (GameObject pic in PicturesList)
            {
                if (pic.GetComponent<DragSprites>().inList == true)
                {
                    pic.SetActive(true);
                }

            }
            ListActive = true;
            
        }
        else
        {
            foreach (GameObject pic in PicturesList)
            {
                if (pic.GetComponent<DragSprites>().inList == true)
                {
                    pic.SetActive(true);
                }

            }
            ListActive = false;
        }
        
    }
    public void AddToListPicture(GameObject picture)
    {
        int i = 0;
        while (PicturesList[i] != null)
        {
            i++;
        }
        PicturesList[i] = picture;
    }
    public void AddPictureToList(GameObject picture)
    {
        PicturesList.Add(picture);
        
    }
}
