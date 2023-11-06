using UnityEngine;

namespace Detective.Hints
{
    public class Hint : MonoBehaviour
    {
        [SerializeField] private HintWindow _hintWindow;

        private void OnMouseDown()
        {
            _hintWindow.Show();
        }
    }
}