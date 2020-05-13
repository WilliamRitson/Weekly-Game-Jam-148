using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public static bool IsSoundsMuted;
    public static bool IsMusicMuted;


    [SerializeField] private int gameSceneBuildIndex;
    [SerializeField] private Sprite playAudioSprite;
    [SerializeField] private Sprite muteAudioSprite;


    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource audioSourceSounds;
    [SerializeField]
    private AudioSource audioSourceMusic;


    [Header("Sounds Info")]
    [SerializeField] private SoundInfo soundInfo;



    [System.Serializable]
    public class SoundInfo
    {
        [Header("Music Audio Clips")]
        public AudioClip mainMusicClip;
        public float mainMusicVolume;
        public AudioClip titleMusicClip;
        public float titleMusicVolume;

        [Header("Game Play Clips")]
        public AudioClip playerHealClip;
        public float playerHealVolume;
        //  public AudioClips playerDamageClip;
        //   public float playerDamageVolume;
       
        public AudioClip flameSpellClip;
        public float flameSpellVolume;

        public AudioClip enemyAlertClip;
        public float enemyAlertVolume;

        public AudioClip flameThrowerClip;
        public float flameThrowerVolume;





    }
    public static AudioManager SharedInstance()
    {
        return AudioManager.Instance;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        IsMusicMuted = false;
        IsSoundsMuted = false;
        PlayTitleMusic();
    }

    public void PlayTitleMusic()
    {
        IsMusicMuted = false;
        IsSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.titleMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();
    }

    public void PlayMainMusic()
    {
        IsMusicMuted = false;
        IsSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.mainMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();
    }

    public void MuteAudio()
    {
        IsMusicMuted = true;
        IsSoundsMuted = true;
        audioSourceMusic.Pause();

        IsMusicMuted = true;
        IsSoundsMuted = true;
        audioSourceMusic.Pause();
    }


    public void UpdateAudioState()
    {
        if (IsMusicMuted && SceneManager.GetActiveScene().buildIndex == gameSceneBuildIndex)
        {
            print("Main played");
            PlayMainMusic();
        }
        else if (IsMusicMuted && SceneManager.GetActiveScene().buildIndex != gameSceneBuildIndex)
        {
            print("Start played");
            PlayTitleMusic();
        }
        else
        {
            print("All Mute");
            MuteAudio();
        }
    }

  /*  public void PlayRandomDamageSound(AudioClip[] audioClips)
    {
        if (audioClips != null && !IsSoundsMuted)
        {
            int rand = Random.Range(0, audioClips.Length);
            if (rand == 1)
            {
                audioSourceSounds.PlayOneShot(audioClips[rand], soundInfo.playerDamageVolume);
            }
            else
            {
                audioSourceSounds.PlayOneShot(audioClips[rand], soundInfo.playerDamageVolume);
            }
        }
    }
    */
    public void PlayRandomHealAudio()
    {
    
        {
            if (!IsSoundsMuted)
            {
                audioSourceSounds.PlayOneShot(soundInfo.playerHealClip, soundInfo.playerHealVolume);
            }
        }
    }
    public void PlayEnemyAlertAudio()
    {

        {
            if (!IsSoundsMuted)
            {
                audioSourceSounds.PlayOneShot(soundInfo.enemyAlertClip, soundInfo.enemyAlertVolume);
            }
        }
    }

    public void PlayFlameSpellAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.flameSpellClip, soundInfo.flameSpellVolume);
        }
    }

    public void PlayFlameThrowerAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.flameThrowerClip, soundInfo.flameThrowerVolume);
        }
    }

}
