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
        public AudioClip buildTowerClip;
        public float buildTowerVolume;
        public AudioClip upgradeTowerClip;
        public float upgradeTowerVolume;
        public AudioClip[] sheepSoundClips;
        public float sheepSoundVolume;
        public AudioClip sheepDiedClip;
        public float sheepDiedVolume;
        public AudioClip destroyTowerClip;
        public float destroyTowerVolume;
        public AudioClip wolfSoundClip;
        public float wolfSoundVolume;
        public AudioClip wolfDiedClip;
        public float wolfDiedVolume;
        public AudioClip throwWeaponClip;
        public float throwWeaponVolume;
        public AudioClip hitWeaponClip;
        public float hitWeaponVolume;
        public AudioClip hunterDiedClip;
        public float hunterDiedVolume;
        public AudioClip wolfHurtClip;
        public float wolfHurtVolume;
        public AudioClip wolfAttackClip;
        public float wolfAttackVolume;
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

    public void PlayRandomDamageSound(AudioClip[] audioClips)
    {
        if (audioClips != null && !IsSoundsMuted)
        {
            int rand = Random.Range(0, audioClips.Length);
            if (rand == 1)
            {
                audioSourceSounds.PlayOneShot(audioClips[rand], soundInfo.sheepSoundVolume);
            }
            else
            {
                audioSourceSounds.PlayOneShot(audioClips[rand], soundInfo.sheepSoundVolume);
            }
        }
    }

    public void PlaySheepDiedAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.sheepDiedClip, soundInfo.sheepDiedVolume);
        }
    }

    public void PlayWolfSoundAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.wolfSoundClip, soundInfo.wolfSoundVolume);
        }
    }

    public void PlayWolfDiedAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.wolfDiedClip, soundInfo.wolfDiedVolume);
        }
    }

    public void PlayWolfHurtAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.wolfHurtClip, soundInfo.wolfHurtVolume);
        }
    }

    public void PlayWolfAttackAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.wolfAttackClip, soundInfo.wolfAttackVolume);
        }
    }

    public void PlayThrowWeaponAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.throwWeaponClip, soundInfo.throwWeaponVolume);
        }
    }

    public void PlayHitWeaponAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.hitWeaponClip, soundInfo.hitWeaponVolume);
        }
    }

    public void PlayBuildTowerAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.buildTowerClip, soundInfo.buildTowerVolume);
        }
    }

    public void PlayDestroyTowerAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.destroyTowerClip, soundInfo.destroyTowerVolume);
        }
    }

    public void PlayUpgradeTowerAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.upgradeTowerClip, soundInfo.upgradeTowerVolume);
        }
    }

    public void PlayHunterDiedAudio()
    {
        if (!IsSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.hunterDiedClip, soundInfo.hunterDiedVolume);
        }
    }
}
