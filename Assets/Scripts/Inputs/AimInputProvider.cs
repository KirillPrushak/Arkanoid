using System;
using UnityEngine;

namespace MyNamespace
{
    public class AimInputProvider : IAimInputProvider
    {
        public event Action OnLaunch;
        private Vector3 _aimTarget;
        public void OnUpdate()
        {
            ProcessLaunchInput();
            ProcessAimInput();
        }
        
        public Vector2 GetAimTarget()
        {
            return _aimTarget;
        }
        
        private void ProcessAimInput()
        {
            _aimTarget = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        private void ProcessLaunchInput()
        {
            if (Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space))
            {
                OnLaunch?.Invoke(); //с проверкой на null, исключение не падает
                // OnLaunch(); //без проверки на null. Если никто не подписан, то упадёт исключение
            }
        }
    }
}