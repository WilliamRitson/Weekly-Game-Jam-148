using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class PlaySoundOnDamage : OnDamageBehavior
{

    [SerializeField] AudioClip[] clips;


    protected override void OnDamaged(int damage)
    {
        AudioManager.Instance.PlayRandomDamageSound(clips);
    }
}
