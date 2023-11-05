using UnityEngine;
using Detective.Suspects;
using System.Collections.Generic;

namespace Detective.Clues
{
    public class CluesHandler : MonoBehaviour
    {
        [SerializeField] private SuspectSO[] _suspects;

        private Dictionary<SuspectSO, SuspectCluesData> _suspectsData;

        private static CluesHandler _instance;
        public static CluesHandler Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(gameObject);
            else
                _instance = this;

            _suspectsData = new Dictionary<SuspectSO, SuspectCluesData>();
            foreach (var suspect in _suspects)
                _suspectsData.Add(suspect, new SuspectCluesData());
        }

        public void ChangeSuspectClueValue(SuspectSO suspect, int value)
        {
            if (_suspectsData.TryGetValue(suspect, out SuspectCluesData data))
                data.ChangeCluesValue(value);
            else
                Debug.LogError("Wrong name: " + suspect.name);
        }

        public int GetSuspectClueValue(SuspectSO suspect)
        {
            if(_suspectsData.TryGetValue(suspect, out SuspectCluesData data))
                return data.CluesValue;
            else
                Debug.LogError("Wrong name: " + suspect.name);
            return 0;
        }
    }
}