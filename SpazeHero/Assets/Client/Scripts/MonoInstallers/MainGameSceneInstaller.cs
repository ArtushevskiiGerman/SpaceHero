using Client.Scripts.MainGameScene.Dependencies;
using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;
using EnemySpawner = Client.Scripts.MainGameScene.EnemySpawner;

public class MainGameSceneInstaller : MonoInstaller
{
    [Header("SpawnPoints")]
    public Transform PlayerSpawnPoint;
    public Transform[] EnemiesSpawnPoints;

    [Header("Camera")]
    public Camera MainCamera;
    
    public override void InstallBindings()
    {
        LocationHandler locationHandler = new LocationHandler(PlayerSpawnPoint, EnemiesSpawnPoints);

        Container.Bind<PlayerStats>().AsSingle().NonLazy();

        Container.Bind<BulletFactory>().AsSingle().NonLazy();

        Container.BindInstances(locationHandler, MainCamera);

        Container.Bind<IFixedTickable>().To<SkyboxRotator>().AsSingle();

        Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();

        Container.BindInterfacesAndSelfTo<PlayerSpawner>().AsSingle().NonLazy();

        Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().NonLazy();
    }
}