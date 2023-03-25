using System;
using MyNamespace;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerMoveController : MonoBehaviour
    {
        [Range(0f, 2f)] [SerializeField] private float _speed = 1f;
        [SerializeField] private float _levelBorderX;
        private IHorizontalInputProvider _horizontalInputProvider;

        private void Awake()
        {
            _horizontalInputProvider = new HorizontalInputController();
        }

        private void Update()
        {
            _horizontalInputProvider.OnUpdate();
        }

        //Перемещение игрока _ только на FixedUpdate
        private void FixedUpdate()
        {
            //Задаём позицию игроку
            var position = transform.position;
            //Перемещение по оси X
            position.x += _horizontalInputProvider.GetCurrentInput() * _speed;

            position.x = Mathf.Clamp(position.x, -_levelBorderX, _levelBorderX);
            //Перезаписываем позицию игроку
            transform.position = position;

        }
    }
}