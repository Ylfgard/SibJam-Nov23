using System.Collections.Generic;
using UnityEngine;

namespace Detective.Hints
{
    public class HintsHandler : MonoBehaviour
    {
        [SerializeField] private HintData[] _hintsData;

        private Dictionary<HintOptionSO, HintWindow> _hints;

        private static HintsHandler _instance;
        public static HintsHandler Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(gameObject);
            else
                _instance = this;

            _hints = new Dictionary<HintOptionSO, HintWindow>();
            foreach (var data in _hintsData)
                _hints.Add(data.Option, data.Hint);
        }

        public void AddHintOption(HintOptionSO option)
        {
            if (_hints.TryGetValue(option, out var hint))
                hint.AddHintOption(option);
            else
                Debug.LogError("Wrong name: " + option.name);
        }
    }
}
