using System;
using UnityEngine;

[Serializable]
public class PlayerCamera
{
    private const float MinRotationX = -60f;
    private const float MaxRotationX = 30f;

    [SerializeField][Range(0.001f, 1f)] private float _mouseSensitivity;

    private float _rotationX;
    private float _rotationY;

    private Camera _camera;
    private Transform _cameraTransform;

    public void Look(Vector2 lookInput, Transform playerTransform)
    {
        lookInput *= _mouseSensitivity;

        _rotationX -= lookInput.y;
        _rotationX = Mathf.Clamp(_rotationX, MinRotationX, MaxRotationX);

        _rotationY += lookInput.x;

        _cameraTransform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        playerTransform.rotation = Quaternion.Euler(0, _rotationY, 0);
    }

    public void Init(Camera camera)
    {
        _camera = camera;
        _cameraTransform = _camera.transform;
    }
}