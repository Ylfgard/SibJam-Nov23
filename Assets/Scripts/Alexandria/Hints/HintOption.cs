using UnityEngine;

public class HintOption : MonoBehaviour
{
    [SerializeField] private GameObject _photo;

    public void AddNewPhoto()
    {
        Instantiate(_photo);
        Destroy(gameObject);
    }
}
