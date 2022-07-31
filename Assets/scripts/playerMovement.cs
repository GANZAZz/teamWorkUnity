using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Speed")]
    public float runSpeed = 3.5f;
    public float JumpForce = 5f;


    private Rigidbody2D _Rigidbody;
    private MoveState _moveState = MoveState.Idle;
    private DirectionState _directionState = DirectionState.Right;
    private Transform _transform;
    private float _walkTime = 0, _walkCooldown = 0.2f;

    public void MoveRight()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Left)
            {
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.lossyScale.y, _transform.localScale.y);
                _directionState = DirectionState.Right;
            }
            _walkTime = _walkCooldown;
        }
    }

    public void MoveLeft()
    {
        if (_moveState != MoveState.Jump)
        {
            _moveState = MoveState.Walk;
            if (_directionState == DirectionState.Right)
            {
                _transform.localScale = new Vector3(-_transform.localScale.x, _transform.localScale.y, _transform.localScale.z);
                _directionState = DirectionState.Left;
            }
            _walkTime = _walkCooldown;
        }
    }

    public void Jump()
    {
        if (_moveState != MoveState.Jump)
        {
            _Rigidbody.velocity = (Vector3.up * JumpForce * Time.deltaTime);
            _moveState = MoveState.Jump;
        }
    }

    private void Idle()
    {
        _moveState = MoveState.Idle;
    }

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _Rigidbody = GetComponent<Rigidbody2D>();
        _directionState = transform.localScale.x > 0 ? DirectionState.Right : DirectionState.Left;
    }

    private void Update()
    {
        if (_moveState == MoveState.Jump)
        {
            if(_Rigidbody.velocity == Vector2.zero)
            {
                Idle();
            }
        }
    }

    enum DirectionState
    {
        Right,
        Left
    }

    enum MoveState
    {
        Idle,
        Walk,
        Jump
    }


}
