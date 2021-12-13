using UnityEngine;

public partial class GameSettings
{
    public class PlayerSettings : IPlayerSettings
    {
        public GameObject PlayerPrefab;
        public int PlayerHealth;
        public float PlayerSpeed;
        public string PlayerTag;

        public PlayerSettings(GameObject playerPrefab, int playerHealth, float playerSpeed, string playerTag)
        {
            PlayerPrefab = playerPrefab;
            PlayerHealth = playerHealth;
            PlayerSpeed = playerSpeed;
            PlayerTag = playerTag;
        }
    }
}