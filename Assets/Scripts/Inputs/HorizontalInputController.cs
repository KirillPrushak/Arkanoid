using System.Collections;
using System.Collections.Generic;
using MyNamespace;
using UnityEngine;

namespace DefaultNamespace
{
    public class HorizontalInputController : HorizontalInputProviderBase
    {
        //Создание интерфейса - задачи конкретных методов, для обработки ввода.
        [SerializeField] private float _horizontalInput;

        //Нажимает ли игрок кнопку передвижения.
        public override void OnUpdate()
        {
            //Универсальный ввод управления.
            _horizontalInput = Input.GetAxis("Horizontal");
        }

        //Возврат к перемещению
        public override float GetCurrentInput(float currentPosition, float speed)
        {
            return currentPosition + _horizontalInput * speed;
        }
    }
}
