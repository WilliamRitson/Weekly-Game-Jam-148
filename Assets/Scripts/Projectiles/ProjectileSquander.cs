﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSquander : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Projectile"))
        {
            collision.GetComponent<Projectile2D>().GetAffectedBySquander();
        }
    }
}
