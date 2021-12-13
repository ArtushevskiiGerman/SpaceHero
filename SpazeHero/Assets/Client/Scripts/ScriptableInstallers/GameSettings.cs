using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Installers/GameSettings")]
public partial class GameSettings : ScriptableObjectInstaller<GameSettings>
{
    [Header("Player settings")]
    public GameObject PlayerPrefab;
    public int PlayerHealth;
    public float PlayerSpeed;
    public string PlayerTag;

    [Space(5f)]
    [Header("Bullet settings")] 
    public GameObject BulletPrefab;
    public float BulletSpeed;
    
    [Space(5f)] 
    [Header("Enemy settings")] 
    public GameObject EnemyPrefab;
    public float EnemySpeed;
    public float EnemyDamage;
    public float EnemyShootRate;
    public float EnemySpawnRate;
    public float DistanceToPlayer;

    [Space(5f)] 
    [Header("SkyboxSettings")] 
    public Material SkyboxMaterial;
    [Range(0, 5)]
    public float SkyboxRotationSpeed;
    
    public override void InstallBindings()
    {
        PlayerSettings playerSettings = new PlayerSettings(PlayerPrefab, PlayerHealth, PlayerSpeed, PlayerTag);
        BulletSettings bulletSettings = new BulletSettings(BulletPrefab, BulletSpeed);
        EnemySettings enemySettings = new EnemySettings(EnemyPrefab, EnemySpeed, EnemyDamage, EnemyShootRate, EnemySpawnRate, DistanceToPlayer);
        SkyboxSettings skyboxSettings = new SkyboxSettings(SkyboxMaterial, SkyboxRotationSpeed);

        InputModule inputModule = new InputModule();
        
        Container.BindInstances(playerSettings, bulletSettings, enemySettings, skyboxSettings, inputModule);
    }
}