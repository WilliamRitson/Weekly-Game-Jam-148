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

    private static Color brown = new Color(114f / 255f, 62f / 255f, 15f / 255f, 1);

    private Color GetElementColor(Element element)
    {
        switch (element)
        {
            case Element.Earth:
                return brown;
            case Element.Fire:
                return Color.red;
            case Element.Water:
                return Color.blue;
            case Element.Wind:
                return Color.cyan;
        }
        return Color.black;
    }
}
