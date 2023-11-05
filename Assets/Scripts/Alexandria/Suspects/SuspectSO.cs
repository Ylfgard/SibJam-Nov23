using UnityEngine;

namespace Detective.Suspects
{
    [CreateAssetMenu (fileName = "New Suspect", menuName = "SO/New Suspect")]
    public class SuspectSO : ScriptableObject
    {
        [SerializeField] private PhotoSO[] _crimeChronology;
            
        public bool CheckCronology(PhotoSO[] chronology)
        {
            int index = 0;
            foreach (PhotoSO photo in chronology)
            {
                if (!CheckCronologyPhoto(photo, ref index))
                    return false;
            }
            return true;
        }

        private bool CheckCronologyPhoto(PhotoSO photo, ref int index)
        {
            for (; index < _crimeChronology.Length; index++)
            {
                if (photo == _crimeChronology[index])
                    return true;
            }
            return false;
        }
    } 
}