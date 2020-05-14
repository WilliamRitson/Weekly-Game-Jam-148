using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMusicSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.SharedInstance().StopAllMusic();
        AudioManager.SharedInstance().PlayLevelMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
