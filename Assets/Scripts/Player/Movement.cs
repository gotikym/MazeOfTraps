using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(InputSystem))]
[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;

    private const string BuffSpeedName = "Speed";
    private const string BuffJumpName = "Jump";

    private float _speedReduction = 1.5f;
    private float _minRotation = -10;
    private float _maxRotation = 0;
    private double _lowMoveStick = 0.2;
    private float _groundCheckDistance = 0.1f;
    private bool _isIced = false;

    private float _normalSpeed;
    private float _normalJumpForce;
    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private Vector2 _direction;
    private Vector2 _rotate;
    private Vector2 _rotation;
    private bool _isGrounded;
    private Coroutine _FreezedTask;
    private Coroutine _BuffJumpTask;
    private Coroutine _BuffSpeedTask;


    public bool IsGrounded => _isGrounded;
    public bool IsIsed => _isIced;

    public event Action RunnedForward;
    public event Action WalkedBack;
    public event Action Jumped;
    public event Action Idled;
    public event Action RunnedLeft;
    public event Action RunnedRight;

    private void Awake()
    {
        _normalSpeed = _moveSpeed;
        _normalJumpForce = _jumpForce;
        _rigidbody = GetComponent<Rigidbody>();
        _input = new PlayerInput();
        _input.Enable();
        _player.Freezed += OnFreezed;
        Dice.Buffed += OnBuffed;
    }

    private void OnDisable()
    {
        _player.Freezed -= OnFreezed;
        Dice.Buffed -= OnBuffed;
    }

    private void FixedUpdate()
    {
        _rotate = _input.Player.Look.ReadValue<Vector2>();
        _direction = _input.Player.Move.ReadValue<Vector2>();

        if (_isIced == false)
        {
            Look(_rotate);
            Move(_direction);
        }

        _isGrounded = Physics.CheckSphere(transform.position, _groundCheckDistance, _groundLayer);
        Idling();
    }

    public void OnJump()
    {
        if (_isGrounded && _isIced == false)
        {
            _rigidbody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
            Jumped?.Invoke();
        }
    }

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < _lowMoveStick)
            return;

        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);

        if (direction.y < 0)
            scaledMoveSpeed = scaledMoveSpeed / _speedReduction;

        transform.position += move * scaledMoveSpeed;
        IdentifyDirection(direction);
    }

    private void Look(Vector2 rotate)
    {
        if (rotate.sqrMagnitude < _lowMoveStick)
            return;

        float scaledRotateSpeed = _rotateSpeed * Time.deltaTime;
        _rotation.y += rotate.x * scaledRotateSpeed;
        _rotation.x = Mathf.Clamp(_rotation.x - rotate.y * scaledRotateSpeed, _minRotation, _maxRotation);
        transform.localEulerAngles = _rotation;
    }

    private void IdentifyDirection(Vector2 direction)
    {
        if (_isGrounded)
        {
            if (direction.y > 0 && direction.x < _lowMoveStick && direction.x > -_lowMoveStick)
                RunnedForward?.Invoke();
            else if (direction.y < 0 && direction.x < _lowMoveStick && direction.x > -_lowMoveStick)
                WalkedBack?.Invoke();
            else if (direction.x > 0)
                RunnedRight?.Invoke();
            else if (direction.x < 0)
                RunnedLeft?.Invoke();
        }
    }

    private void Idling()
    {
        if (_isGrounded && _direction == Vector2.zero && _rotate == Vector2.zero)
            Idled?.Invoke();
    }

    private void OnFreezed(float delay)
    {
        _isIced = true;

        if (_FreezedTask != null)
            StopCoroutine(_FreezedTask);

        _FreezedTask = StartCoroutine(Unfreeze(delay));
    }

    private IEnumerator Unfreeze(float delay)
    {
        yield return new WaitForSeconds(delay);
        _isIced = false;
    }

    private void OnBuffed(Buff buff)
    {
        switch (buff.Name)
        {
            case BuffSpeedName:
                SpeedBuff(buff.Strength, buff.Duration);
                break;
            case BuffJumpName:
                JumpBuff(buff.Strength, buff.Duration);
                break;
        }
    }

    private void SpeedBuff(float strength, float duration)
    {
        _moveSpeed += strength;

        if (_BuffSpeedTask != null)
            StopCoroutine(_BuffSpeedTask);

        _BuffSpeedTask = StartCoroutine(SpeedBuffDurationTimer(duration, strength));        
    }

    private void JumpBuff(float strength, float duration)
    {
        _jumpForce += strength;

        if (_BuffJumpTask != null)
            StopCoroutine(_BuffJumpTask);

        _BuffJumpTask = StartCoroutine(JumpBuffDurationTimer(duration, strength));        
    }

    private IEnumerator JumpBuffDurationTimer(float duration, float strength)
    {
        yield return new WaitForSeconds(duration);
        _jumpForce = _normalJumpForce;
    }

    private IEnumerator SpeedBuffDurationTimer(float duration, float strength)
    {
        yield return new WaitForSeconds(duration);
        _moveSpeed = _normalSpeed;
    }
}