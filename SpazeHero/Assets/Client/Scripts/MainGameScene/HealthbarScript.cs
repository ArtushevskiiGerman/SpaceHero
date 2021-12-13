using System;
using Client.Scripts.MainGameScene.Dependencies;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HealthbarScript : MonoBehaviour
{
    private PlayerStats _playerStats;
    private Image _image;
    private Material _material;
    private readonly int _currentHealthValue = Shader.PropertyToID("CurrentHealthValue");

    [Inject]
    private void Construct(PlayerStats playerStats)
    {
        _playerStats = playerStats;
    }

    private void Start()
    {
        _image = GetComponent<Image>();
        _material = _image.material;
    }

    private void FixedUpdate()
    {
        _material.SetFloat(_currentHealthValue, _playerStats.Health);
    }
}
