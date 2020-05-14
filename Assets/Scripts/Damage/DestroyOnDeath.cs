public class DestroyOnDeath : OnDeathBehavior
{
    protected override void OnDeath()
    {
        AudioManager.SharedInstance().PlayRandomEnemyDeathSound();
        Destroy(gameObject);
    }
}
