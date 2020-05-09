using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCanves : MonoBehaviour
{
    //[SerializeField] private int startSceneBuildIndex;
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject pausePanel;
   

    public void UpdatePauseState()
    {
        if (Time.timeScale == 0)
        {
            pauseBtn.SetActive(true);
            pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            pauseBtn.SetActive(false);
            pausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void UpdateAudioState()
    {
        AudioManager.Instance.UpdateAudioState();
    }

    public void LoadStartScene(int gameSceneIndex)
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        SceneManager.LoadScene(gameSceneIndex);
    }
}
