using UnityEngine;

namespace Detective.Hints
{
    [System.Serializable]
    public class HintData
    {
        [SerializeField] private HintOptionSO _option;
        [SerializeField] private Hint _hint;

        public HintOptionSO Option => _option;
        public Hint Hint => _hint;
    }
}
