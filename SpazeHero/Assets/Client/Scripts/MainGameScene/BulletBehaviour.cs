using System;
using UnityEngine;
using Zenject;

public class BulletBehaviour : MonoBehaviour
{
    private GameSettings.BulletSettings _bulletSettings;
    private Rigidbody _rb;
    
    [Inject]
    private void Construct(GameSettings.BulletSettings bulletSettings)
    {
        _bulletSettings = bulletSettings;
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.AddRelativeForce(Vector3.left * _bulletSettings.BulletSpeed * Time.fixedDeltaTime, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHandler>().GetDamage();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        
        Destroy(gameObject);
    }
}
