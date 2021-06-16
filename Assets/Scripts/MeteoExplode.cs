using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoExplode : MonoBehaviour
{
    public float delay = 3f;
    public GameObject explosionEffect;
    //public GameObject burningEffect;
    bool hasExploded = false;

    float countdown;

    void Start()
    {
        countdown = delay;
        //Instantiate(burningEffect);
    }

    void Update()
    {
        countdown -= Time.deltaTime;
        if (countdown <= 0f && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
