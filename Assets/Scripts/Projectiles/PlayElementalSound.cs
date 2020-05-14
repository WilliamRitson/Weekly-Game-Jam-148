using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Projectile2D))]

public class PlayElementalSound : MonoBehaviour
{
    void Start()
    {
        switch (GetComponent<Projectile2D>().damageType)
        {
            case Element.Earth:
                AudioManager.SharedInstance().PlayRockSpellAudio();
                return;
            case Element.Fire:
                AudioManager.SharedInstance().PlayFlameSpellAudio();
                return;
            case Element.Water:
                AudioManager.SharedInstance().PlayWaterSpellAudio();
                return;
            case Element.Wind:
                AudioManager.SharedInstance().PlayWaterSpellAudio();
                return;
        }
    }
}
