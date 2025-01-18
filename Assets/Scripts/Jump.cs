using System;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField, Min(1)]
    private float _targetVelocity = 5.0f;

    private Rigidbody2D _rigidbody = default;
    private PlayerInput _input = default;
    private bool _isAlive = true;

    private void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _input.onActionTriggered += OnActionTriggered;
        Death.DeathLayerTouched += OnDeathLayerTouched;
    }

    private void Start()
    {
        _isAlive = true;
    }

    private void OnDisable()
    {
        Death.DeathLayerTouched -= OnDeathLayerTouched;
        _input.onActionTriggered -= OnActionTriggered;
    }

    private void OnActionTriggered(InputAction.CallbackContext context)
    {
        if (context.action.name == "Jump" && context.phase == InputActionPhase.Started && _isAlive)
            OnJump();
    }

    private void OnJump()
    {
        _rigidbody.linearVelocityY = _targetVelocity;
    }

    private void OnDeathLayerTouched()
    {
        _isAlive = false;
    }
}
