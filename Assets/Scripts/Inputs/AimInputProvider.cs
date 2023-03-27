using System;
using UnityEngine;

namespace MyNamespace
{
    public class AimInputProvider : IAimInputProvider
    {
        public event Action OnLaunch;
        private Vector3 _aimTarget;
        // ReSharper disable Unity.PerformanceAnalysis
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
            // если щёлкнули лкм или нажали пробел
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                OnLaunch?.Invoke(); // с проверкой на null, исключение не падает

                // такая же запись, более длинная
                // if (OnLaunch != null)
                // {
                //     OnLaunch.Invoke();
                // }


                // OnLaunch(); // без проверки на null. Если никто не подписан, то упадёт исключение
            }
        }
    }
}