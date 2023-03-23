using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    //Создание интерфейса - задачи конкретных методов, для обработки ввода.
    public interface IInputProvider
    {
        public void OnUpdate();
        public float GetCurrentInput();
    }
    [SerializeField] private float _horizontalInput;

    //Нажимает ли игрок кнопку передвижения.
    public void OnUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal"); //Универсальный ввод управления.
    }

    //Возврат к перемещению
    public float GetCurrentInput()
    {
        return _horizontalInput;
    }
}
