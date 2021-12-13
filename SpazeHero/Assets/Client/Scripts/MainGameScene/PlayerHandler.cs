using System;
using Client.Scripts.MainGameScene.Dependencies;
using Unity.Mathematics;
using UnityEngine;
using Zenject;
using Screen = UnityEngine.Device.Screen;

public class PlayerHandler : MonoBehaviour
{
    private InputModule _inputModule;
    private GameSettings.PlayerSettings _playerSettings;
    private GameSettings.EnemySettings _enemySettings;
    private PlayerStats _playerStats;

    private Vector2 _movementVector;

    private Rigidbody _rigidbody;

    private Camera _mainCamera;

    private Transform _transform;

    [SerializeField] private GunScript _gunScript;

    public delegate void PlayerDeath();

    public static event PlayerDeath PlayerDied;

    [Inject]
    private void Construct(InputModule inputModule,
                            GameSettings.PlayerSettings playerSettings,
                            PlayerStats playerStats,
                            Camera mainCamera,
                            GameSettings.EnemySettings enemySettings)
    {
        _inputModule = inputModule;
        _playerSettings = playerSettings;
        _playerStats = playerStats;
        _mainCamera = mainCamera;
        _enemySettings = enemySettings;

        _rigidbody = GetComponent<Rigidbody>();
        _transform = GetComponent<Transform>();

        _inputModule.Player.Fire.performed += _ => Attack();
    }

    private void OnEnable()
    {
        _inputModule.Enable();
    }

    private void OnDisable()
    {
        _inputModule.Disable();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Attack()
    {
        _gunScript.Fire();
    }

    private void Move()
    {
        _movementVector = _inputModule.Player.Movement.ReadValue<Vector2>();
        _movementVector *= _playerSettings.PlayerSpeed;
        
        _rigidbody.AddForce(new Vector3(_movementVector.x, _movementVector.y, 0f), ForceMode.Force);
    }

    private void Rotate()
    {
        Vector2 mousePos = _inputModule.Player.MousePos.ReadValue<Vector2>();
        
        Ray mouseRay = _mainCamera.ScreenPointToRay(mousePos);

        Vector3 point = mouseRay.GetPoint(10f);

        _transform.LookAt(new Vector3(point.x, point.y, 0f));
    }

    public void GetDamage()
    {
        _playerStats.Health -= _enemySettings.EnemyDamage;

        if (_playerStats.Health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
        
        PlayerDied?.Invoke();;
    }
}