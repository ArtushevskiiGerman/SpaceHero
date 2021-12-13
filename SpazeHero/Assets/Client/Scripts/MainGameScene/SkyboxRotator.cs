using UnityEngine;
using Zenject;

public class SkyboxRotator : IFixedTickable
{
    private const string ShaderVariableName = "_Rotation";
    
    private Material _skybox;
    private float _rotationSpeed;
    
    [Inject]
    private void Construct(GameSettings.SkyboxSettings SkyboxSettings)
    {
        _skybox = SkyboxSettings.SkyboxMaterial;
        _rotationSpeed = SkyboxSettings.SkyboxRotationSpeed;
    }
    
    public void FixedTick()
    {
        _skybox.SetFloat(ShaderVariableName,
            _skybox.GetFloat(ShaderVariableName)
            + _rotationSpeed * Time.fixedDeltaTime);
    }
}
