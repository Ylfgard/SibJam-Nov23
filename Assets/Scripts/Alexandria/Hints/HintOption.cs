using UnityEngine;
using UnityEngine.UI;

public class HintOption : MonoBehaviour
{
    [SerializeField] private GameObject _photo;

    public void AddNewPhoto()
    {
        Instantiate(_photo);
    }
}
