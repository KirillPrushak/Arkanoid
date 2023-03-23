using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0f, 2f)] [SerializeField] private float _speed = 1f;
    private IHorizontalInputProvider _horizontalInputProvider;
    void Awake ()
    {
        _horizontalInputProvider = new HorizontalInputController();
    }

    // Update is called once per frame
    void Update()
    {
        var position = transform.position;
        position.x += _horizontalInputProvider.GetCurrentInput() * _speed;
    }
}

public class HorizontalInputController : IHorizontalInputProvider //движение объекта по горизонтали
{
    public float _horizontalInput;

    public void OnUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    public float GetCurrentInput()
    {
        return _horizontalInput;
    }
    
}

public interface IHorizontalInputProvider
{
    float GetCurrentInput();
}
