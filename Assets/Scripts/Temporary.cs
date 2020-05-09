using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporary : MonoBehaviour
{
    public float lifespan = 0.4f;

    // Update is called once per frame
    void Update()
    {
        if (enabled) {
            lifespan -= Time.deltaTime;
            if (lifespan <= 0) {
                Destroy(gameObject);
            }
        }
    }
}
