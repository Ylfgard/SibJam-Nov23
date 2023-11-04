using UnityEngine;

namespace Detective.Clues
{
    public class SuspectCluesData
    {
        [SerializeField] private int _cluesValue;

        public int CluesValue => _cluesValue;

        public SuspectCluesData()
        {
            _cluesValue = 0;
        }

        public void ChangeCluesValue(int value)
        {
            _cluesValue += value;
        }
    }
}