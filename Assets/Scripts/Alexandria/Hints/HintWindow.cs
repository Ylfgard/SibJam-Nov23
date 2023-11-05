using System;
using UnityEngine;
using UnityEngine.UI;

namespace Detective.Hints
{
    public class HintWindow : MonoBehaviour
    {
        [SerializeField] private Button _closeButton;
        [SerializeField] private GameObject _windowBody;
        [SerializeField] private RectTransform _content;

        private void Awake()
        {
            _closeButton.onClick.AddListener(Close);
            Close();
        }

        public void AddHintOption(HintOptionSO option)
        {
            Instantiate(option.Prefab, _content);
        }

        public void Show()
        {
            _windowBody.SetActive(true);
        }

        private void Close()
        {
            _windowBody.SetActive(false);
        }
    }
}