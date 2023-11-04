using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Detective.Clues
{
    public class Photo : MonoBehaviour
    {
        private const string ShowTrigger = "Show";
        private const string HideTrigger = "Hide";

        [SerializeField] private Animator m_animator;

        public void Show()
        {
            m_animator.SetTrigger(ShowTrigger);
        }

        public void Hide()
        {
            m_animator.SetTrigger(HideTrigger);
        }
    }
}