using UnityEngine;
using Zenject;

class BulletFactory
{
    private readonly GameSettings.BulletSettings _bulletSettings;
    private readonly DiContainer _container;
    
    public BulletFactory(DiContainer container, GameSettings.BulletSettings bulletSettings)
    {
        _container = container;
        _bulletSettings = bulletSettings;
    }

    public void Create(Vector3 position, Quaternion rotation)
    {
        _container.InstantiatePrefab(_bulletSettings.BulletPrefab, position, rotation, null);
    }
}