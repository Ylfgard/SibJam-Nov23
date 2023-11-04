using Detective.Suspects;
using UnityEngine;
using UnityEngine.UI;

namespace Detective.Clues
{
    public class Clue : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private ClueData[] _cluesData;

        private void Awake()
        {
            _toggle.onValueChanged.AddListener(SelectChanged);
        }

        private void SelectChanged(bool state)
        {
            if (state)
                foreach (var data in _cluesData)
                    CluesHandler.Instance.ChangeSuspectClueValue(data.SuspectName, data.Value);
            else
                foreach (var data in _cluesData)
                    CluesHandler.Instance.ChangeSuspectClueValue(data.SuspectName, -data.Value);
        }
    }
}