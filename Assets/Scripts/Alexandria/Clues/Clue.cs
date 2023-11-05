using Detective.Hints;
using UnityEngine;
using UnityEngine.UI;

namespace Detective.Clues
{
    public class Clue : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private HintOptionSO _hintOption;
        [SerializeField] private ClueData[] _cluesData;

        private bool _hintNotAdded;

        private void Awake()
        {
            _toggle.onValueChanged.AddListener(SelectChanged);
            _hintNotAdded = true;
        }

        private void SelectChanged(bool state)
        {
            if (state)
            {
                foreach (var data in _cluesData)
                    CluesHandler.Instance.ChangeSuspectClueValue(data.Suspect, data.Value);
                if (_hintNotAdded)
                    HintsHandler.Instance.AddHintOption(_hintOption);
            }
            else
            {
                foreach (var data in _cluesData)
                    CluesHandler.Instance.ChangeSuspectClueValue(data.Suspect, -data.Value);
            }
        }
    }
}