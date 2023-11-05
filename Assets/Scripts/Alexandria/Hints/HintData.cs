using UnityEngine;

namespace Detective.Hints
{
    [System.Serializable]
    public class HintData
    {
        [SerializeField] private HintOptionSO _option;
        [SerializeField] private HintWindow _hint;

        public HintOptionSO Option => _option;
        public HintWindow Hint => _hint;
    }
}
