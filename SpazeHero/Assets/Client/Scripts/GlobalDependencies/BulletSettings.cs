using UnityEngine;

public partial class GameSettings
{
    public class BulletSettings : IBulletSettings
    {
        public GameObject BulletPrefab;
        public float BulletSpeed;

        public BulletSettings(GameObject bulletPrefab, float bulletSpeed)
        {
            BulletPrefab = bulletPrefab;
            BulletSpeed = bulletSpeed;
        }
    }
}