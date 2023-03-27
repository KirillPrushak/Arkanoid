using System;
using MyNamespace;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.PlayerLoop;
using UnityEngine.WSA;
using Application = UnityEngine.Application;

namespace DefaultNamespace
{
    public class BallLauncher : MonoBehaviour
    {
        [SerializeField] private float _launchSpeed = 1f;
        [SerializeField] private Rigidbody2D _ball;
        private IAimInputProvider _inputProvider;

        private void Start()
        {
            _inputProvider = new AimInputProvider();
            _inputProvider.OnLaunch += Launch;
            
            //Шар будет следить за платформой
            _ball.transform.parent = transform;
        }

        //Метод работающий по подписке, вызов метода OnLaunch
        private void Launch()
        {
            //Отписались, отсутствие вызова
            _inputProvider.OnLaunch -= Launch;
            
            //Вектор направления из шара в позицию мышки (прицела)
            var shootDirection = _inputProvider.GetAimTarget() - _ball.position;
            
            //Вектор направления в длину равным скорости запуска
            shootDirection.Normalize();
            shootDirection *= _launchSpeed;
            
            //Запускаем шар с полученной силой
            _ball.transform.parent = null;
            _ball.AddForce(shootDirection, ForceMode2D.Impulse);
        }

        private void Update()
        {
            _inputProvider.OnUpdate();
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying) return;
            Gizmos.color = Color.red;
            var targetPos = _inputProvider.GetAimTarget();
            var initialPos = transform.position;
            Gizmos.DrawLine(initialPos, targetPos);
        }
    }
}