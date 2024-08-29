using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerCharacter : MonoBehaviour, IDamagable
{
    private const KeyCode JumpInput = KeyCode.Space;
    private const KeyCode ShootInput = KeyCode.Mouse0;

    [SerializeField] private PlayerCamera _camera;
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private Shooter _shooter;

    [field: SerializeField] public HealthView HealthView { get; private set; }

    private InputsControl _inputs;
    private Transform _transform;

    public Transform Transform => _transform;

    private void Awake()
    {
        _inputs = new InputsControl();
        _playerMover.Init(GetComponent<Rigidbody>());
        _transform = transform;
    }

    private void OnEnable() => 
        _inputs.Enable();

    private void Update()
    {
        _playerMover.Move(_inputs.Character.Move.ReadValue<Vector2>(), _transform);
        _camera.Look(_inputs.Character.Look.ReadValue<Vector2>(), _transform);

        if (Input.GetKeyDown(JumpInput) && _playerMover.IsGrounded())
            _playerMover.Jump();

        if (Input.GetKeyDown(ShootInput))
            _shooter.Shoot();
    }

    private void FixedUpdate() => 
        _playerMover.FixedUpdate();

    private void OnDisable() => 
        _inputs.Disable();

    public void Init(int maxHealth)
    {
        _shooter.Init();
        _camera.Init(Camera.main);
        HealthView.Init(new Health(maxHealth));
    }
}