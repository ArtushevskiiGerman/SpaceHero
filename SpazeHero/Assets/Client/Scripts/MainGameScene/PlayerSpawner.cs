using UnityEngine;
using Zenject;

public class PlayerSpawner : IInitializable
{
    private GameObject _prefab;
    private Transform _spawnPoint;
    private DiContainer _container;
    
    public PlayerSpawner(GameSettings.PlayerSettings playerSettings, LocationHandler locationHandler, DiContainer container)
    {
        _prefab = playerSettings.PlayerPrefab;
        _spawnPoint = locationHandler.PlayerSpawnPoint;
        _container = container;
    }

    public void Initialize()
    {
        _container.InstantiatePrefab(_prefab, _spawnPoint.position, Quaternion.identity, null);
    }
}
