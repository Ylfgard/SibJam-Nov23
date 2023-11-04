using Detective.Suspects;
using UnityEngine;

namespace Detective.Clues
{
    [System.Serializable]
    public class ClueData
    {
        [SerializeField] private SuspectSO _suspect;
        [SerializeField] private int _value;

        public string SuspectName => _suspect.Name;
        public int Value => _value;
    }
}