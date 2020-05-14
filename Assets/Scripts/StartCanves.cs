using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanves : MonoBehaviour
{
    public void Start()
    {
        AudioManager.SharedInstance().StopAllMusic();
    }
    public void Play(int gameSceneIndex)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(gameSceneIndex);
    }

    public void UpdateAudioState()
    {
        AudioManager.Instance.UpdateAudioState();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
