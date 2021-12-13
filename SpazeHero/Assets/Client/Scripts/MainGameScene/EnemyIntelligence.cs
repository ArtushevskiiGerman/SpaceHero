using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

// TODO : Complete this class and add big brain to enemy
public class EnemyIntelligence : MonoBehaviour
{
    private GameSettings.EnemySettings _enemySettings;
    private Transform _playerTransform;
    private Transform _myTransform;
    private Rigidbody _myRigidbody;
    [SerializeField] private GunScript _gunScript;

    private bool playerAlive = true;

    private float _timeToShoot = 0.5f;

    [Inject]
    private void Construct(GameSettings.PlayerSettings playerSettings, GameSettings.EnemySettings enemySettings)
    {
        _playerTransform = GameObject.FindWithTag(playerSettings.PlayerTag).GetComponent<Transform>();
        _enemySettings = enemySettings;

        _myTransform = GetComponent<Transform>();
        _myRigidbody = GetComponent<Rigidbody>();

        PlayerHandler.PlayerDied += PlayerDied;
    }

    private void FixedUpdate()
    {
        if (!playerAlive) return;
        
        _myTransform.LookAt(_playerTransform);
        TryMove();
        TryShoot();
    }

    private void PlayerDied()
    {
        playerAlive = false;
    }

    private void TryShoot()
    {
        if (!playerAlive) return;   
        
        if (_timeToShoot <= 0f)
        {
            _gunScript.Fire();
            _timeToShoot = _enemySettings.EnemyShootRate;
        }
        else
        {
            _timeToShoot -= Time.fixedDeltaTime;
        }
        
    } 

    private void TryMove()
    {
        if (!playerAlive) return;
        
        if (Vector3.Distance(_myTransform.position, _playerTransform.position) <= _enemySettings.DistanceToPlayer) return;

        Vector3 directionToPlayer = _playerTransform.position - _myTransform.position;

        _myRigidbody.AddForce(directionToPlayer.normalized * _enemySettings.EnemySpeed, ForceMode.Force);
    }
}
