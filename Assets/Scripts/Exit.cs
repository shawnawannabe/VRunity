using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private bool gazedOn;
    public float gazeTime = 2f;
    private float timer;
    
    void Update()
    {
        if (gazedOn)
        {
            timer += Time.deltaTime;
            if ( timer > gazeTime)
            {
                Quit();
            }
        }
    }

    public void PointerEnter()
    {
        gazedOn = true;
    }

    public void PointerExit()
    {
        gazedOn = false;
    }

    public void Quit()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
