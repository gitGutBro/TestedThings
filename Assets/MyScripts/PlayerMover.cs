using System;
using UnityEngine;

[Serializable]
public class PlayerMover
{
    private const float TouchRadius = 0.1f;

    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravityScale;
    [SerializeField] private LayerMask _groundMask;
    [SerializeField] private Transform _groundToucher;

    private Rigidbody _rigidbody;

    public void Move(Vector2 moveInput, Transform playerTransform) => 
        _rigidbody.velocity = GetDirection(moveInput, playerTransform) * _speed;

    public void Jump() => 
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);

    public bool IsGrounded() =>
        Physics.CheckSphere(_groundToucher.position, TouchRadius, _groundMask, QueryTriggerInteraction.Ignore);

    public void FixedUpdate() => 
        _rigidbody.AddForce((_gravityScale - 1) * _rigidbody.mass * Physics.gravity);

    public void Init(Rigidbody rigidbody) =>
        _rigidbody = rigidbody;

    private Vector3 GetDirection(Vector2 moveInput, Transform transform) =>
        transform.forward * moveInput.y + transform.right * moveInput.x;
}