using System.Collections;
using System.Collections.Generic;
using MyNamespace;
using UnityEngine;

public partial class HorizontalInputController : MonoBehaviour, IHorizontalInputProvider
{
    //Создание интерфейса - задачи конкретных методов, для обработки ввода.
    [SerializeField] private float _horizontalInput;

    //Нажимает ли игрок кнопку передвижения.
    public void OnUpdate()
    {
        //Универсальный ввод управления.
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    //Возврат к перемещению
    public float GetCurrentInput()
    {
        return _horizontalInput;
    }
}
