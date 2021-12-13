using UnityEngine;
using Zenject;

public class GunScript : MonoBehaviour
{
    private GameSettings.BulletSettings _bulletSettings;
    private BulletFactory _bulletFactory;
    [SerializeField] private Transform _gunPoint;
    
    [Inject]
    private void Construct(GameSettings.BulletSettings bulletSettings, BulletFactory bulletFactory)
    {
        _bulletSettings = bulletSettings;
        _bulletFactory = bulletFactory;
    }

    public void Fire()
    {
        _bulletFactory.Create(_gunPoint.position, _gunPoint.rotation);
    }
}
