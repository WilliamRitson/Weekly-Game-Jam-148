using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;


    [SerializeField] private Sprite playAudioSprite;
    [SerializeField] private Sprite muteAudioSprite;


    [Header("Audio Sources")]
    [SerializeField]
    private AudioSource audioSourceSounds;
    [SerializeField]
    private AudioSource audioSourceMusic;


    [Header("Sounds Info")]
    [SerializeField] private SoundInfo soundInfo;

    private static bool isSoundsMuted = false;

    private static bool isMusicMuted;


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
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        isMusicMuted = false;
        isSoundsMuted = false;
        PlayTitleMusic();
    }

    public void PlayTitleMusic()
    {
        isMusicMuted = false;
        isSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.titleMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();
    }

    public void PlayMainMusic()
    {
        isMusicMuted = false;
        isSoundsMuted = false;
        audioSourceMusic.clip = soundInfo.mainMusicClip;
        audioSourceMusic.loop = true;
        audioSourceMusic.Play();
    }

    public void MuteMainMusic()
    {
        isMusicMuted = true;
        isSoundsMuted = true;
        audioSourceMusic.Pause();

        isMusicMuted = true;
        isSoundsMuted = true;
        audioSourceMusic.Pause();
    }


    public void UpdateMusicState()
    {
        if (isMusicMuted)
        {
            PlayMainMusic();
        }
        else
        {
            MuteMainMusic();
        }
    }

    public void PlayRandomDamageSound(AudioClip[] audioClips)
    {
        if (audioClips != null && !isSoundsMuted)
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
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.sheepDiedClip, soundInfo.sheepDiedVolume);
        }
    }

    public void PlayWolfSoundAudio()
    {
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.wolfSoundClip, soundInfo.wolfSoundVolume);
        }
    }

    public void PlayWolfDiedAudio()
    {
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.wolfDiedClip, soundInfo.wolfDiedVolume);
        }
    }

    public void PlayWolfHurtAudio()
    {
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.wolfHurtClip, soundInfo.wolfHurtVolume);
        }
    }

    public void PlayWolfAttackAudio()
    {
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.wolfAttackClip, soundInfo.wolfAttackVolume);
        }
    }

    public void PlayThrowWeaponAudio()
    {
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.throwWeaponClip, soundInfo.throwWeaponVolume);
        }
    }

    public void PlayHitWeaponAudio()
    {
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.hitWeaponClip, soundInfo.hitWeaponVolume);
        }
    }

    public void PlayBuildTowerAudio()
    {
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.buildTowerClip, soundInfo.buildTowerVolume);
        }
    }

    public void PlayDestroyTowerAudio()
    {
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.destroyTowerClip, soundInfo.destroyTowerVolume);
        }
    }

    public void PlayUpgradeTowerAudio()
    {
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.upgradeTowerClip, soundInfo.upgradeTowerVolume);
        }
    }

    public void PlayHunterDiedAudio()
    {
        if (!isSoundsMuted)
        {
            audioSourceSounds.PlayOneShot(soundInfo.hunterDiedClip, soundInfo.hunterDiedVolume);
        }
    }
}
