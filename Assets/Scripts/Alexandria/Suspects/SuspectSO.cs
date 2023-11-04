using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Detective.Suspects
{
    [CreateAssetMenu (fileName = "New Suspect", menuName = "SO/New Suspect")]
    public class SuspectSO : ScriptableObject
    {
        [SerializeField] private string _name;

        public string Name => _name;
    } 
}