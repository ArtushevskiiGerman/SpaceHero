using System.Collections;
using UnityEngine;
using Zenject;

namespace Client.Scripts.MainGameScene
{
    public class EnemySpawner : IFixedTickable
    {
        private IEnemyFactory _enemyFactory;
        private GameSettings.EnemySettings _enemySettings;

        private float _cooldown;
        private float _timeSince;

        private bool playerAlive = true;
        
        public EnemySpawner(IEnemyFactory enemyFactory, GameSettings.EnemySettings enemySettings)
        {
            _enemyFactory = enemyFactory;
            _enemySettings = enemySettings;

            _cooldown = _enemySettings.EnemySpawnRate;
            _timeSince = 0f;

            PlayerHandler.PlayerDied += PlayerDie;
        }

        public void FixedTick()
        {
            TrySpawnEnemy();
        }

        private void PlayerDie()
        {
            playerAlive = false;
        }
            
        private void TrySpawnEnemy()
        {
            if (!playerAlive) return;

            if (_timeSince >= _cooldown)
            {
                _enemyFactory.Create();
                _timeSince = 0f;
            }
            else
            {
                _timeSince += Time.fixedDeltaTime;
            }
        }

    }
}