using System;
using MyNamespace;
using UnityEngine;

namespace DefaultNamespace
{
    public class LaserPointerView : MonoBehaviour
    {
        [SerializeField] private IAimInputProvider _aimInputProvider;

        private void Update()
        {
            // Повернуться в сторону прицела
            Vector3 targetPoint = _aimInputProvider.GetAimTarget();
            
            transform.LookAt(targetPoint);

            // Следить за позицией игрока
        }
    }
}