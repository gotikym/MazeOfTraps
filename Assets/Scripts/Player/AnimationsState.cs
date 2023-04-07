using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationsState : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    private const string AnimationIdle = "FoxIdle";
    private const string AnimationRun = "FoxRun";
    private const string AnimationWalkBack = "FoxWalkBack";
    private const string AnimationJump = "FoxJump";
    private const string AnimationRunLeft = "FoxRunLeft";
    private const string AnimationRunRigth = "FoxRunRight";

    private Animator _animator;

    private void Awake()
    {
        _movement.RunnedForward += OnRunned;
        _movement.WalkedBack += OnWalkedBack;
        _movement.Jumped += OnJumped;
        _movement.Idled += OnIdled;
        _movement.RunnedLeft += OnRunnedLeft;
        _movement.RunnedRight += OnRunnedRight;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();       
    }

    private void Update()
    {
        if(_movement.IsGrounded == false)
            _animator.Play(AnimationJump);            
    }

    private void OnDisable()
    {
        _movement.RunnedForward -= OnRunned;
        _movement.WalkedBack += OnWalkedBack;
        _movement.Jumped -= OnJumped;
        _movement.Idled -= OnIdled;
        _movement.RunnedLeft -= OnRunnedLeft;
        _movement.RunnedRight -= OnRunnedRight;
    }

    public void OnRunned()
    {
        _animator.Play(AnimationRun);
    }

    public void OnWalkedBack()
    {
        _animator.Play(AnimationWalkBack);
    }

    private void OnJumped()
    {
        _animator.Play(AnimationJump);
    }

    private void OnIdled()
    {
        _animator.Play(AnimationIdle);
    }

    private void OnRunnedLeft()
    {
        _animator.Play(AnimationRunLeft);
    }

    private void OnRunnedRight()
    {
        _animator.Play(AnimationRunRigth);
    }
}
