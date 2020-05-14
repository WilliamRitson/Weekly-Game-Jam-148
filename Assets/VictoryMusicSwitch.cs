using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryMusicSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.SharedInstance().StopAllMusic();
        AudioManager.SharedInstance().PlayVictoryMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
