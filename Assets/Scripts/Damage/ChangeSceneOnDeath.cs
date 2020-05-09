using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnDeath : OnDeathBehavior
{
    public string sceneName;
    protected override void OnDeath()
    {
        SceneManager.LoadScene(sceneName);
    }
}