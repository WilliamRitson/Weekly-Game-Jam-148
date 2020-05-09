
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeSceneOnDeath : OnDeathBehavior
{
    [SerializeField] private float secBeforLoadingStartScene;//seconds to wait before load the start scene after the player died
    public int startSceneBuildIndex;

    protected override void OnDeath()
    {
        StartCoroutine(LoadStartScene());
        damagable.OnDeath -= OnDeath;
    }

    public IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(secBeforLoadingStartScene);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(startSceneBuildIndex);
    }
}