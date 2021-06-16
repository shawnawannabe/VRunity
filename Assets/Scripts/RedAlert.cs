using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedAlert : MonoBehaviour
{
    public float gazeTime = 2f;
    private GameObject meteorite;
    private float timer;
    private bool gazedAt;
    public string scene;

    void Start()
    {
        meteorite = GameObject.Find("Meteorite");
    }

    void Update()
    {
        if (gazedAt)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime)
            {
                meteorite.gameObject.SetActive(true);
                gameObject.SetActive(false);
                Interaction.WalkSpeed = 4;
            }
        }

    }

    public void PointerEnter()
    {
        gazedAt = true;
    }

    public void PointerExit()
    {
        gazedAt = false;
    }
}
