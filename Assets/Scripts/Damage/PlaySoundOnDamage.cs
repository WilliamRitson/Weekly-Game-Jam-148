using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnDamage : OnDamageBehavior
{

    [SerializeField] AudioClip[] clips;
    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    protected override void OnDamaged(int damage)
    {
        source.clip = clips[Random.Range(0, clips.Length - 1)];
        source.Play();
    }
}
