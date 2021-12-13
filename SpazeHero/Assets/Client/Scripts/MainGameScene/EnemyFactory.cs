using UnityEngine;
using Zenject;

public class EnemyFactory : IEnemyFactory
{
    private readonly Transform[] _spawnPositions;
    private readonly GameObject _enemyPrefab;

    private readonly DiContainer _container;

    public EnemyFactory(LocationHandler locationHandler,
                        GameSettings.EnemySettings enemySettings,
                        DiContainer container)
    {
        _spawnPositions = locationHandler.EnemiesSpawnPoints;
        _enemyPrefab = enemySettings.EnemyPrefab;
        _container = container;
    }

    public GameObject Create()
    {
        Transform spawnPosition = _spawnPositions[Random.Range(0, _spawnPositions.Length)];

        return _container?.InstantiatePrefab(_enemyPrefab, spawnPosition.position, Quaternion.identity, null);
    }
}
