namespace Client.Scripts.MainGameScene.Dependencies
{
    public class PlayerStats
    {
        public float Health;
        
        public PlayerStats(GameSettings.PlayerSettings _playerSettings)
        {
            Health = _playerSettings.PlayerHealth;
        }
    }
}