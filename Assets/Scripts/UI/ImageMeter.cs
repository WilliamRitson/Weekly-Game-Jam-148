using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageMeter : Meter
{
    [SerializeField] private Image avatar;
    [SerializeField] private Sprite[] images;

    override protected void SetHealth(int newValue)
    {
        int index = Math.Min(Math.Max(images.Length - newValue, 0), images.Length - 1);
        avatar.sprite = images[index];
    }
}
