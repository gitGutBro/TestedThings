using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MyBullet : MonoBehaviour, IPoolObject
{
    [SerializeField][Range(3f, 10f)] private float _speed;
    [SerializeField] private float _disapperanceCooldown;

    [field: SerializeField] public int Damage { get; private set; }

    private float _currentCooldown;
    private Vector2 _direction;
    private Transform _transform;
    private Rigidbody _rigidbody;
    private IPoolReturner<IPoolObject> _returner;

    public Transform Transform => _transform;

    private void Awake()
    {
        _transform = transform;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_currentCooldown < _disapperanceCooldown)
        {
            _currentCooldown += Time.deltaTime;
            return;
        }

        _currentCooldown = 0;

        ReturnInPool();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out IDamagable damagable))
        {
            damagable.HealthView.Health.Decrease(Damage);
            ReturnInPool();
        }
    }

    public void SetDirection(Vector2 direction)
    {
        if (direction == null || direction == Vector2.zero)
            throw new NullReferenceException($"Direction is null or zero: {GetType()}");

        _direction = direction;
        _rigidbody.velocity = _direction * _speed;
    }

    public void ReturnInPool() =>
        _returner.Return(this);

    public void SetReturner(IPoolReturner<IPoolObject> returner) =>
        _returner = returner ?? throw new ArgumentNullException();
}