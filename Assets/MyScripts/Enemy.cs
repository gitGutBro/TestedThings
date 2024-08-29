using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour, IDamagable
{
    [SerializeField] private float _stopDistance;
    [SerializeField] private float _shootRange;
    [SerializeField] private Shooter _shooter;
    [SerializeField] private Transform _target;
    [SerializeField] private HealthView _healthView;

    private NavMeshAgent _agent;
    private Transform _transform;

    public HealthView HealthView { get; private set; }
    private float DistanceToPlayer => Vector3.Distance(_target.position, _transform.position);

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _shooter.Init();
    }

    private void Start() => 
        _transform = transform;

    private void Update()
    {
        if (DistanceToPlayer > _stopDistance)
            _agent.SetDestination(_target.position);
        else
            _agent.SetDestination(_transform.position);

        if (DistanceToPlayer > _shootRange)
            return;

        _shooter.Shoot();
    }
}