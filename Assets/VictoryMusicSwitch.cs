using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMusicSwitch : MonoBehaviour
{
    void Start()
    {
        AudioManager.SharedInstance().StopAllMusic();
        AudioManager.SharedInstance().PlayVictoryMusic();
        StartCoroutine(ReturnToMenuAfterTime());
    }

    IEnumerator ReturnToMenuAfterTime()
    {
        yield return new WaitForSeconds(23);
        SceneManager.LoadScene("StartScene");
    }

}
