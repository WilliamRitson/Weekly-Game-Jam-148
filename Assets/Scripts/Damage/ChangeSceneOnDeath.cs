<<<<<<< HEAD
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class ChangeSceneOnDeath : OnDeathBehavior
{
    [SerializeField] private float secBeforLoadingStartScene;//seconds to wait before load the start scene after the player died
    public int startSceneBuildIndex;

=======
﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnDeath : OnDeathBehavior
{
    public string sceneName;
>>>>>>> 5871ed09d80f542888068f4cb02e0b21106dcc0e
    protected override void OnDeath()
    {
        StartCoroutine(LoadStartScene());
        damagable.OnDeath -= OnDeath;
    }
<<<<<<< HEAD

    public IEnumerator LoadStartScene()
    {
        yield return new WaitForSeconds(secBeforLoadingStartScene);
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(startSceneBuildIndex);
        
    }
=======
>>>>>>> 5871ed09d80f542888068f4cb02e0b21106dcc0e
}