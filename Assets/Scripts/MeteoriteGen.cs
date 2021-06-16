using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteGen : MonoBehaviour
{
    public Transform meteo1;
    public Transform meteo2;
    public int xPos;
    public int zPos;
    public int objectToGenerate;
    bool started = true;
    //public int objectQuantity;

    // Start is called before the first frame update
    void Update()
    {
        if (started)
        {
            StartCoroutine(GenerateObjects());
        }
        
    }

    IEnumerator GenerateObjects()
    {
        started = false;
        while(true)
        {
            objectToGenerate = Random.Range(1, 3);
            xPos = Random.Range(-7, -66);
            zPos = Random.Range(14, -60);
            if (objectToGenerate == 1)
            {
                Instantiate(meteo1, new Vector3(xPos, 25, zPos), Quaternion.identity);
            }
            if (objectToGenerate == 2)
            {
                Instantiate(meteo2, new Vector3(xPos, 25, zPos), Quaternion.identity);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    
}
