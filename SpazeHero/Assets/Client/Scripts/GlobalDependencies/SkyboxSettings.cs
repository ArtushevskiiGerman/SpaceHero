using UnityEngine;

public partial class GameSettings
{
    public class SkyboxSettings : ISkyboxSettings
    {
        public Material SkyboxMaterial;
        public float SkyboxRotationSpeed;

        public SkyboxSettings(Material skyboxMaterial, float skyboxRotationSpeed)
        {
            SkyboxMaterial = skyboxMaterial;
            SkyboxRotationSpeed = skyboxRotationSpeed;
        }
    }
}