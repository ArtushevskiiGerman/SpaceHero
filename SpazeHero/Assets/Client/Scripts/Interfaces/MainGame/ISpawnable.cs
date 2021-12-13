using UnityEngine;

namespace Client.Scripts.Interfaces.MainGame
{
    public interface ISpawnable
    {
        GameObject GetPrefab();
        
        Vector3 GetPosition();
    }
}