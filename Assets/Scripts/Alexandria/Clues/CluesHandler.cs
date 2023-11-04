using UnityEngine;
using Detective.Suspects;
using System.Collections.Generic;

namespace Detective.Clues
{
    public class CluesHandler : MonoBehaviour
    {
        [SerializeField] private SuspectSO[] _suspects;

        private Dictionary<string, SuspectCluesData> _suspectsData;

        private static CluesHandler _instance;
        public static CluesHandler Instance => _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
                Destroy(gameObject);
            else
                _instance = this;

            _suspectsData = new Dictionary<string, SuspectCluesData>();
            foreach (var suspect in _suspects)
                _suspectsData.Add(suspect.Name, new SuspectCluesData());
        }

        public void ChangeSuspectClueValue(string name, int value)
        {
            if (_suspectsData.TryGetValue(name, out SuspectCluesData suspect))
                suspect.ChangeCluesValue(value);
            else
                Debug.LogError("Wrong name: " + name);
        }
    }
}