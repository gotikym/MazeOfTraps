using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private DebuffState _debuffState;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundLayer;

    private float _speedReduction = 2;
    private float _minRotation = -10;
    private float _maxRotation = 0;
    private double _lowMoveStick = 0.1;
    private float _groundCheckDistance = 0.1f;
    private bool _isIced = false;

    private Rigidbody _rigidbody;
    private PlayerInput _input;
    private Vector2 _direction;
    private Vector2 _rotate;
    private Vector2 _rotation;
    private bool _isGrounded;

    public bool IsGrounded => _isGrounded;
    public bool IsIsed => _isIced;

    public event UnityAction RunnedForward;
    public event UnityAction WalkedBack;
    public event UnityAction Jumped;
    public event UnityAction Idled;
    public event UnityAction RunnedLeft;
    public event UnityAction RunnedRight;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _input = new PlayerInput();
        _input.Enable();
        _debuffState.Iced += OnIced;
    }

    private void OnDisable()
    {
        _debuffState.Iced -= OnIced;
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

    private void Move(Vector2 direction)
    {
        if (direction.sqrMagnitude < _lowMoveStick)
            return;

        float scaledMoveSpeed = _moveSpeed * Time.deltaTime;
        Vector3 move = Quaternion.Euler(0, transform.eulerAngles.y, 0) * new Vector3(direction.x, 0, direction.y);

        if (direction.y < 0)
            scaledMoveSpeed = scaledMoveSpeed / _speedReduction;

        transform.position += move * scaledMoveSpeed;
        MovedStraight(direction);
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

    private void OnJump()
    {
        if (_isGrounded)
        {
            _rigidbody.AddForce(_jumpForce * Vector3.up, ForceMode.Impulse);
            Jumped?.Invoke();
        }
    }

    private void MovedStraight(Vector2 direction)
    {
        if (_isGrounded)
        {
            if (direction.y > 0 && direction.x == 0)
                RunnedForward?.Invoke();
            else if (direction.y < 0 && direction.x == 0)
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

    private void OnIced(float delay)
    {
        _isIced = true;
        StartCoroutine(Unfreeze(delay));
    }

    private IEnumerator Unfreeze(float delay)
    {
        yield return new WaitForSeconds(delay);
        _isIced = false;
    }
}