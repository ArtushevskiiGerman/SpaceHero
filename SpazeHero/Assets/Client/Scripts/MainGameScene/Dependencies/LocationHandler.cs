using UnityEngine;

public class LocationHandler : ILocationHandler
{
    public readonly Transform PlayerSpawnPoint;
    public readonly Transform[] EnemiesSpawnPoints;

    public LocationHandler(Transform playerSpawnPoint, Transform[] enemiesSpawnPoints)
    {
        PlayerSpawnPoint = playerSpawnPoint;
        EnemiesSpawnPoints = enemiesSpawnPoints;
    }

    public Transform GetPlayerSpawner()
    {
        return PlayerSpawnPoint;
    }

    public Transform GetEnemySpawner()
    {
        return EnemiesSpawnPoints[Random.Range(0, EnemiesSpawnPoints.Length - 1)];
    }
}