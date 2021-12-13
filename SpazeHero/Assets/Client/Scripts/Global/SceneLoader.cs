using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public const string BootSceneName = "BootScene";
    public const string MainMenuName = "MainMenu";
    public const string MainGameName = "MainGame";
    
    public static void LoadScene(Scenes scene)
    {
        if (scene == Scenes.Boot) SceneManager.LoadScene(BootSceneName);
        else if (scene == Scenes.Menu) SceneManager.LoadScene(MainMenuName);
        else if (scene == Scenes.Game) SceneManager.LoadScene(MainGameName);
    }

    public static void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}