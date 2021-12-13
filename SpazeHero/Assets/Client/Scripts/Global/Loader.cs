using UnityEngine;

public class Loader : MonoBehaviour
{
    [SerializeField] private Scenes _scene;
    [SerializeField] private bool LoadOnStart = false;

    private void Start()
    {
        if (LoadOnStart)
            SceneLoader.LoadScene(_scene);
    }

    public void Load()
    {
        SceneLoader.LoadScene(_scene);
    }
}