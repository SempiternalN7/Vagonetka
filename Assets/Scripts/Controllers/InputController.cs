﻿using UnityEngine;


namespace Vagonetka
{
    public class InputController : MonoBehaviour
    {
        public bool InputStarted = false;

        [SerializeField] private KeyCode _keyForFallGold;

        private Camera _сameraForInput;
        private Touch touch;
        private bool _isActive;

        private GoldController _goldController;

        private void Start()
        {
            _goldController = FindObjectOfType<GoldController>();
            _сameraForInput = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            if (!_isActive) return;

#if UNITY_EDITOR
            if (Input.GetKeyDown(_keyForFallGold))
            {
                FallGold();
            }
#endif

            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    InputStarted = true;
                    FallGold();
                }
            }
            else if (InputStarted)
            {
                InputStarted = false;
            }
        }

        private void FallGold()
        {
            _goldController.GetCurrentGold().Fall();
            _goldController.SwitchNextGold();
        }

        public void ActivateController(bool state)
        {
            _isActive = state;
        }
    }
}