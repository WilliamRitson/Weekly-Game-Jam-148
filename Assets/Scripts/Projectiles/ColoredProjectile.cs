using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Projectile2D))]

[RequireComponent(typeof(SpriteRenderer))]
public class ColoredProjectile : MonoBehaviour
{
    void Start()
    {
        var renderer = GetComponent<SpriteRenderer>();
        var color = GetElementColor(GetComponent<Projectile2D>().damageType);
        renderer.color = color;
    }

    private Color GetElementColor(Element element)
    {
        switch (element)
        {
            case Element.Earth:
                return new Color(40, 26, 13);
            case Element.Fire:
                return Color.red;
            case Element.Water:
                return Color.red;
            case Element.Wind:
                return Color.cyan;
        }
        return Color.black;
    }
}
