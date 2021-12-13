using UnityEngine;

public partial class GameSettings
{
    public class EnemySettings : IEnemySettings
    {
        public GameObject EnemyPrefab;
        public float EnemySpeed;
        public float EnemyDamage;
        public float EnemyShootRate;
        public float EnemySpawnRate;
        public float DistanceToPlayer;

        public EnemySettings(GameObject enemyPrefab, float enemySpeed,float enemyDamage, float enemyShootRate, float enemySpawnRate, float distanceToPlayer)
        {
            EnemyPrefab = enemyPrefab;
            EnemySpeed = enemySpeed;
            EnemyShootRate = enemyShootRate;
            EnemySpawnRate = enemySpawnRate;
            DistanceToPlayer = distanceToPlayer;
            EnemyDamage = enemyDamage;
        }
    }
}