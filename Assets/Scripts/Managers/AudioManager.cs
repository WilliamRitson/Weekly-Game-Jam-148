using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public static bool IsSoundsMuted;
    public static bool IsMusicMuted;
    private int randomSound;

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
        public AudioClip bossMusicClip;
        public float bossMusicVolume;
        public AudioClip levelMusicClip;
        public float levelMusicVolume;
        public AudioClip victoryMusicClip;
        public float victoryMusicVolume;



        [Header("Game Play Clips")]
        public AudioClip playerHealClip;
        public float playerHealVolume;
        public AudioClip playerDamageClip;
        public float playerDamageVolume;

        public AudioClip flameSpellClip;
        public float flameSpellVolume;

        public AudioClip rockSpellClip;
        public float rockSpellVolume;

        public AudioClip waterSpellClip;
        public float waterSpellVolume;

        public AudioClip windSpellClip;
        public float windSpellVolume;

        public AudioClip enemyAlertClip;
        public float enemyAlertVolume;

        public AudioClip flameThrowerClip;
        public float flameThrowerVolume;

        public AudioClip windShieldClip;
        public float windShieldVolume;

        public AudioClip rockSpecialClip;
        public float rockSpecialVolume;

        public AudioClip playerDeathClip;
        public float playerDeathVolume;

        public AudioClip shapeShiftClip;
        public float shapeShiftVolume;

        public AudioClip[] enemyDeathClip;
        public float enemyDeathVolume;
    }
    public static AudioManager SharedInstance()
    {
        return AudioManager.Instance;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance.gameObject);
        }
       
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        IsMusicMuted = false;
        IsSoundsMuted = false;
        PlayTitleMusic();
    }

    public void PlayTitleMusic()
    {
        Debug.Log("Play title music");
        IsMusicMuted = false;
        IsSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.titleMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();
    }
    public void PlayLevelMusic()
    {
        Debug.Log("Play title music");
        IsMusicMuted = false;
        IsSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.levelMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();
    }

    public void PlayMainMusic()
    {
        Debug.Log("Play main music");
        IsMusicMuted = false;
        IsSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.mainMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();
    }

    public void PlayBossMusic()
    {
        Debug.Log("Start boss music");
        IsMusicMuted = false;
        IsSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.bossMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();
    }

    public void PlayVictoryMusic()
    {
        Debug.Log("Start boss music");
        IsMusicMuted = false;
        IsSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.victoryMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();
    }

    public void StopAllMusic()
    {
       
        if(PlayerPrefs.GetInt("IsMusicPlaying",0)==0)
        {
            foreach (var audio in GetComponents<AudioSource>())
            {
                audio.Stop();
            }
        }
        else
        {
            foreach (var audio in GetComponents<AudioSource>())
            {
                audio.Play();
            }
        }
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
    public void PlayRandom(AudioClip[] audioClips)
    {
        if (audioClips != null && !IsSoundsMuted)
        {
            int rand = Random.Range(0, audioClips.Length);
            if (rand == 1)
            {
                audioSourceSounds.PlayOneShot(audioClips[rand], soundInfo.enemyDeathVolume);
            }
            else
            {
                audioSourceSounds.PlayOneShot(audioClips[rand], soundInfo.enemyDeathVolume);
            }
        }
    }
    public void PlayDamageAudio()
    {

        {
            if (!IsSoundsMuted)
            {
                audioSourceSounds.PlayOneShot(soundInfo.playerDamageClip, soundInfo.playerDamageVolume);
            }
        }
    }

    public void PlayRandomEnemyDeathSound()
    {
        randomSound = Random.Range(0, 3);
        audioSourceSounds.PlayOneShot(soundInfo.enemyDeathClip[randomSound], soundInfo.enemyDeathVolume);
    }
    
    public void PlayRandomHealAudio()
    {
    
        {
            if (!IsSoundsMuted)
            {
                audioSourceSounds.PlayOneShot(soundInfo.playerHealClip, soundInfo.playerHealVolume);
            }
        }
    }

    public void PlayShapeShiftAudio()
    {

        {
            if (!IsSoundsMuted)
            {
                audioSourceSounds.PlayOneShot(soundInfo.shapeShiftClip, soundInfo.shapeShiftVolume);
            }
        }
    }
    public void PlayWindShieldAudio()
    {

        {
            if (!IsSoundsMuted)
            {
                audioSourceSounds.PlayOneShot(soundInfo.windShieldClip, soundInfo.windShieldVolume);
            }
        }
    }
    public void PlayRockSpecialAudio()
    {

        {
            if (!IsSoundsMuted)
            {
                audioSourceSounds.PlayOneShot(soundInfo.rockSpecialClip, soundInfo.rockSpecialVolume);
            }
        }
    }
    public void PlayPlayerDeathAudio()
    {

        {
            if (!IsSoundsMuted)
            {
                audioSourceSounds.PlayOneShot(soundInfo.playerDeathClip, soundInfo.playerDeathVolume);
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
    public void PlayRockSpellAudio()
    {

        {
            if (!IsSoundsMuted)
            {
                audioSourceSounds.PlayOneShot(soundInfo.rockSpellClip, soundInfo.rockSpellVolume);
            }
        }
    }
    public void PlayWaterSpellAudio()
    {

        {
            if (!IsSoundsMuted)
            {
                audioSourceSounds.PlayOneShot(soundInfo.waterSpellClip, soundInfo.waterSpellVolume);
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

    public void PlayWindSpellAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.windSpellClip, soundInfo.windSpellVolume);
        }
    }

    public void PlayFlameThrowerAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.flameThrowerClip, soundInfo.flameThrowerVolume);
        }
    }

 /*   public void ChangeBGM(AudioClip music)
    {
        if (audioSourceMusic.clip.name == music.name)
            return;

        audioSourceMusic.Stop();
        audioSourceMusic.clip = music;
        audioSourceMusic.Play();
    }
    */
}

