using Detective.Suspects;
using UnityEngine;

namespace Detective.Clues
{
    [System.Serializable]
    public class ClueData
    {
        [SerializeField] private SuspectSO _suspect;
        [SerializeField] private int _value;

        public SuspectSO Suspect => _suspect;
        public int Value => _value;
    }
}