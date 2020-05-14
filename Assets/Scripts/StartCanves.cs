using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanves : MonoBehaviour
{
    public AudioSource AudioSource;
    int isPlaying;
    public void Start()
    {
        //AudioManager.SharedInstance().StopAllMusic();
        isPlaying = PlayerPrefs.GetInt("IsMusicPlaying", 0);
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
        //AudioManager.Instance.UpdateAudioState();
        isPlaying = PlayerPrefs.GetInt("IsMusicPlaying", 0);
        if (isPlaying==0)
        {
            AudioSource.Stop();
            PlayerPrefs.SetInt("IsMusicPlaying", 1);
        }
        else
        {
            AudioSource.Play();
            PlayerPrefs.SetInt("IsMusicPlaying", 0);
        }
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
