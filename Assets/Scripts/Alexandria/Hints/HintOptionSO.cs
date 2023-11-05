using UnityEngine;

namespace Detective.Hints
{
    [CreateAssetMenu(fileName = "New Hint Option", menuName = "SO/New Hint Option")]
    public class HintOptionSO : ScriptableObject
    {
        [SerializeField] private GameObject _prefab;

        public GameObject Prefab => _prefab;
    }
}